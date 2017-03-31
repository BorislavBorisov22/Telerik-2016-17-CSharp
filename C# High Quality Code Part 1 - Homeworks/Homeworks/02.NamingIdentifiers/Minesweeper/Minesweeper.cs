namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main()
        {
            string command = string.Empty;

            char[,] playingField = GetInitialBoard();
            char[,] fieldWithMines = PlaceMines();

            int successfullMoves = 0;
            bool isOnBomb = false;

            List<Player> players = new List<Player>(6);

            int row = 0;
            int column = 0;

            bool isStartingGame = true;
            bool isGameWon = false;

            const int MaxNonBombCells = 35;

            do
            {
                if (isStartingGame)
                {
                    Console.WriteLine("Let's play some minesweeper. Try to open up all the boxes that do not have mines" +
                    " Enter -> 'top' for ranking, 'restart' for starting a new game, 'exit' to quit game!");
                    DrawPlayingBoard(playingField);
                    isStartingGame = false;
                }

                Console.Write("Select a row and a column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= playingField.GetLength(0) && column <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetPlayersRanking(players);
                        break;
                    case "restart":
                        playingField = GetInitialBoard();
                        fieldWithMines = PlaceMines();
                        DrawPlayingBoard(playingField);

                        isOnBomb = false;
                        isStartingGame = false;

                        break;
                    case "exit":
                        Console.WriteLine("See you soon, bye :)!");
                        break;
                    case "turn":
                        if (fieldWithMines[row, column] != '*')
                        {
                            if (fieldWithMines[row, column] == '-')
                            {
                                MakePlayersMove(playingField, fieldWithMines, row, column);
                                successfullMoves++;
                            }

                            if (MaxNonBombCells == successfullMoves)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                DrawPlayingBoard(playingField);
                            }
                        }
                        else
                        {
                            isOnBomb = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command\n");
                        break;
                }

                if (isOnBomb)
                {
                    DrawPlayingBoard(fieldWithMines);
                    Console.Write("\nHrrrrrr! Game Over!You scored {0} points. " + "Enter your nickname: ", successfullMoves);

                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, successfullMoves);

                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    GetPlayersRanking(players);

                    playingField = GetInitialBoard();
                    fieldWithMines = PlaceMines();

                    successfullMoves = 0;

                    isOnBomb = false;
                    isStartingGame = true;
                }

                if (isGameWon)
                {
                    Console.WriteLine("\nBRAVOOO! You opened all 35 safe boxes.");
                    DrawPlayingBoard(fieldWithMines);
                    Console.WriteLine("Enter you nickname, bro: ");

                    string nickname = Console.ReadLine();
                    Player currentPlayer = new Player(nickname, successfullMoves);

                    players.Add(currentPlayer);
                    GetPlayersRanking(players);

                    playingField = GetInitialBoard();
                    fieldWithMines = PlaceMines();

                    successfullMoves = 0;

                    isGameWon = false;
                    isStartingGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Come again soon.");
            Console.Read();
        }

        private static void GetPlayersRanking(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakePlayersMove(char[,] playingField, char[,] mines, int row, int col)
        {
            char minesAroundCurrentBox = GetMinesCountAroundBox(mines, row, col);
            mines[row, col] = minesAroundCurrentBox;
            playingField[row, col] = minesAroundCurrentBox;
        }

        private static void DrawPlayingBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < boardRows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < boardCols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GetInitialBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int fieldRows = 5;
            int fieldCols = 10;

            char[,] playingField = new char[fieldRows, fieldCols];

            for (int row = 0; row < fieldRows; row++)
            {
                for (int col = 0; col < fieldCols; col++)
                {
                    playingField[row, col] = '-';
                }
            }

            Random randomGenerator = new Random();

            List<int> minesHolder = new List<int>();

            while (minesHolder.Count < 15)
            {
                int mineIndex = randomGenerator.Next(50);

                if (!minesHolder.Contains(mineIndex))
                {
                    minesHolder.Add(mineIndex);
                }
            }

            foreach (int mineIndex in minesHolder)
            {
                int row = mineIndex / fieldCols;
                int col = mineIndex % fieldCols;

                if (col == 0 && mineIndex != 0)
                {
                    row--;
                    col = fieldCols;
                }
                else
                {
                    col++;
                }

                playingField[row, col - 1] = '*';
            }

            return playingField;
        }

        private static char GetMinesCountAroundBox(char[,] playfield, int currentRow, int currentCol)
        {
            int score = 0;
            int rows = playfield.GetLength(0);
            int cols = playfield.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (playfield[currentRow - 1, currentCol] == '*')
                {
                    score++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (playfield[currentRow + 1, currentCol] == '*')
                {
                    score++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (playfield[currentRow, currentCol - 1] == '*')
                {
                    score++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (playfield[currentRow, currentCol + 1] == '*')
                {
                    score++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (playfield[currentRow - 1, currentCol - 1] == '*')
                {
                    score++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (playfield[currentRow - 1, currentCol + 1] == '*')
                {
                    score++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (playfield[currentRow + 1, currentCol - 1] == '*')
                {
                    score++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (playfield[currentRow + 1, currentCol + 1] == '*')
                {
                    score++;
                }
            }

            return char.Parse(score.ToString());
        }
    }
}
