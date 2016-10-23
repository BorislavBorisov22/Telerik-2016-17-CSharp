using System;
using System.Diagnostics;
using System.Threading;

class FallingRocks
{


    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        // Global Initializing
        var rng = new Random();
        var score = Stopwatch.StartNew();
        Console.BufferWidth = Console.WindowWidth = 60;
        Console.BufferHeight = Console.WindowHeight = 30;

        var rockPositions = new int[30, 45];
        int playFieldWidth = 40;
        int playFieldHeight = 30;

        // Dwarf Initialization
        string dwarfSymbol = "(0)";
        int dwarfX = playFieldWidth / 2;
        int dwarfY = playFieldHeight - 1;

        //Game Loop
        bool isGameOver = false;
        while (!isGameOver)
        {
            Console.Clear();
            // read keys
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                while (Console.KeyAvailable == true) Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarfX - 1 > 0)
                    {
                        dwarfX -= 2;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarfX + 2 < playFieldWidth - 1)
                    {
                        dwarfX += 2;
                    }
                }
            }

            // create rocks

            int currRowRocks = rng.Next(1, 4);

            for (int i = 0; i < currRowRocks; i++)
            {
                int currRockPosition = rng.Next(0, playFieldWidth);
                rockPositions[0, currRockPosition] = 1;
            }
            //move rocks down
            for (int row = playFieldHeight - 1; row >= 0; row--)
            {
                for (int col = 0; col < playFieldWidth; col++)
                {
                    if (rockPositions[row, col] == 1)
                    {
                        rockPositions[row, col] = 0;
                        rockPositions[row + 1, col] = 1;
                    }
                }
            }
            // check for collision
            bool isThereCollison;
            int counterHits = 0;
            for (int col = 0; col < playFieldWidth; col++)
            {
                bool hasDwarfBeenHit = rockPositions[29, col] == 1 &&
                    (dwarfX == col || dwarfX + 1 == col || dwarfX + 2 == col);

                if (hasDwarfBeenHit)
                {
                    counterHits++;
                }
            }
            if (counterHits == 0)
            {
                isThereCollison = false;
            }
            else
            {
                isThereCollison = true;
            }
            // print dwarf 
            Console.SetCursorPosition(dwarfX, dwarfY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(dwarfSymbol);

            //print rocks 
            for (int row = 0; row < playFieldHeight; row++)
            {
                for (int col = 0; col < playFieldWidth; col++)
                {
                    if (rockPositions[row, col] == 1)
                    {
                        int rockLength = rng.Next(1, 3);
                        char rockType = RandomiseRockSymbol(rng);
                        Console.ForegroundColor = RandomiseColor(rng);
                        Console.SetCursorPosition(col, row);
                        for (int i = 0; i < rockLength; i++)
                        {
                            Console.Write(rockType);
                        }
                    }
                }
            }


            //clear bottom row
            for (int col = 0; col < playFieldWidth; col++)
            {
                if (rockPositions[playFieldHeight - 1, col] == 1)
                {
                    rockPositions[playFieldHeight - 1, col] = 0;
                }
            }


            // print score 
            Console.SetCursorPosition(playFieldWidth + 6, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Score: {0}", score.ElapsedMilliseconds / 100);
            //check if game is over
            if (isThereCollison)
            {
                isGameOver = true;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Game over!\n\nYour scroe is {0}\n\nThank you for playing Falling Rocks ;)"
                    , score.ElapsedMilliseconds / 100);
            }
            // constant game speed
            Thread.Sleep(250);
        }


    }



    private static char RandomiseRockSymbol(Random rng)
    {
        char[] rockSymbols = { '@', '+', '-', '=', '*', '&', '.', '$', '/', '!', '#', '^' };
        //^, @, *, &, +, %, $, #, !, ., ;, -
        int rockNumber = rng.Next(1, rockSymbols.Length);

        return rockSymbols[rockNumber];
    }

    private static ConsoleColor RandomiseColor(Random rng)
    {
        ConsoleColor[] colors = { ConsoleColor.Blue,ConsoleColor.Black,ConsoleColor.Magenta,
        ConsoleColor.Yellow,ConsoleColor.DarkRed};

        int numberColor = rng.Next(0, colors.Length);

        return colors[numberColor];

    }
}

