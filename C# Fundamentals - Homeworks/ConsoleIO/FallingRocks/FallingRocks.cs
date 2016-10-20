using System;
using System.Threading;
using System.Security.Cryptography;

/*
 * Implement the "Falling Rocks" game in the text console.
 * A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
 * A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
 * Rocks are the symbols  ^, @, *, &, +, %, $, #, !, ., ;, -  distributed with appropriate density. The dwarf is  (O) .
 * Ensure a constant game speed by  Thread.Sleep(150) .
 * Implement collision detection and scoring system.
*/

/*       How to Play    */
/*
 * Left arrow - move dwarf left
 * Right arrow - move dwarf right
 * Down arrow - decrease game speed
 * Up arrow - increase game speed
 *
 * If game over click ENTER to start new game
*/

class FallingRocks
{
    //config
    static int consoleWidth = 20;
    static int consoleHeight = 25;
    static int gameInfoHeight = 5;

    static int rocksPerRowMin = 0;
    static int rocksPerRowMax = 2;
    static int rocksMaxOnField = 30;

    static int defaultGameSpeed = 150;

    static ConsoleColor dwarfColor = ConsoleColor.DarkYellow;
    static int dwarfArmor = 5;

    static string formatGameInfo = "\nSpeed: {0,-10}\nArmor: {1}\nScore: {2,-10}";
    static string strGameOver = "G A M E  O V E R !\n";
    //////////////////////////////////

    //generating real random numbers
    static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

    //speed info
    static int gameSpeed = defaultGameSpeed;

    //score info
    static int score = 0;
    static int armor = dwarfArmor;

    //rocks info
    struct __Rock
    {

        public char rockSymbol;
        public ConsoleColor rockColor;
    };

    static int rocksCurrentCount = 0;
    static __Rock[,] Rocks = new __Rock[consoleHeight, consoleWidth];
    static char[] rockForms = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    static ConsoleColor[] rockColors = { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkRed };

    //Dwarf info
    static string dwarf = "(0)";
    static int dwarfX = ((consoleWidth - 1) / 2);
    static int dwarfY = consoleHeight - 1;

    static void Main()
    {

        Console.CursorVisible = false;
        Console.WindowHeight = consoleHeight + gameInfoHeight;
        Console.WindowWidth = consoleWidth;

        while (true)
        {

            moveRocksDown();
            drawNewRow();
            drawRocks();

            showGameInfo();

            //check if dwarf is being hit by rock
            if (dwarfCollision() == true)
            {
                gameOver();
                continue;
            }

            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow: //move right
                        {
                            if (dwarfX < consoleWidth - 1) { dwarfX++; }
                            break;
                        }

                    case ConsoleKey.LeftArrow: //move left
                        {
                            if (dwarfX > 0) { dwarfX--; }
                            break;
                        }
                    case ConsoleKey.UpArrow: //increase game speed
                        {
                            if (gameSpeed > 100)
                            {

                                gameSpeed -= 100;

                            }
                            else if (gameSpeed > 10)
                            {
                                gameSpeed -= 10;
                            }

                            break;
                        }
                    case ConsoleKey.DownArrow: //slow down game speed
                        {
                            gameSpeed += 100;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            //check if dwarf steps on position where is rock
            if (dwarfCollision() == true)
            {
                gameOver();
                continue;
            }

            drawDwarf();

            Thread.Sleep(gameSpeed);
        }
    }

    static void showGameInfo() //show score, armor, game speed
    {
        string strGameInfo = String.Format(formatGameInfo, gameSpeed, armor, score);
        string strLine = "";
        strLine = strLine.PadLeft(consoleWidth, '*');

        ConsoleWriteEx(ref strLine, '\0', 0, consoleHeight, ConsoleColor.White);
        ConsoleWriteEx(ref strGameInfo, '\0', 0, consoleHeight + 1, ConsoleColor.Gray);
    }

    static void gameOver() //prints game over message on the screen
    {
        int x = (consoleWidth / 2) - (strGameOver.Length / 2);
        int y = consoleHeight / 2;

        ConsoleWriteEx(ref strGameOver, '\0', x, y, ConsoleColor.Red);

        ConsoleKeyInfo key;
        do
        {

            key = Console.ReadKey();

        } while (key.Key != ConsoleKey.Enter);

        resetGame();
    }

    static void resetGame() //after game over we reset the game field for new game :)
    {
        for (int y = 0; y < consoleHeight; y++)
        {
            for (int x = 0; x < consoleWidth; x++)
            {
                Rocks[y, x].rockSymbol = '\0';
            }
        }

        dwarfX = ((consoleWidth - 1) / 2);
        dwarfY = consoleHeight - 1;

        rocksCurrentCount = 0;

        gameSpeed = defaultGameSpeed;
        armor = dwarfArmor;
        score = 0;
    }

    static bool dwarfCollision() //check if dwarf is being hit by an rock
    {
        bool bCollision = false;

        for (int y = consoleHeight - 1, x = dwarfX; x < (dwarfX + dwarf.Length); x++)
        {
            if (Rocks[y, x].rockSymbol != '\0') //if dwarf is hit, we remove his armor by one
            {
                if (armor == 0) { bCollision = true; } //if dwarf has no armor, then game over :(
                armor--;
                Rocks[y, x].rockSymbol = '\0';

                break;
            }
        }

        return bCollision;
    }

    static void drawDwarf() //draws the dwarf on the screen
    {
        ConsoleWriteEx(ref dwarf, '\0', dwarfX, dwarfY, dwarfColor);
    }

    static void drawRocks() //draws all rocks on the screen
    {
        string strNull = null;

        for (int y = 0; y < consoleHeight; y++)
        {
            for (int x = 0; x < consoleWidth; x++)
            {
                ConsoleWriteEx(ref strNull, Rocks[y, x].rockSymbol, x, y, Rocks[y, x].rockColor);
            }
        }
    }


    static void moveRocksDown() //Move rocks one row down
    {
        //Before losing the last down row, check how many rocks we remove from the field
        //so we know how many new rocks we can spawn and also increase score
        for (int y = consoleHeight - 1, x = 0; x < consoleWidth; x++)
        {
            if (Rocks[y, x].rockSymbol != '\0')
            {

                rocksCurrentCount--;
                score += Rocks[y, x].rockSymbol;
            }
        }

        //Move rocks one row down
        for (int y = consoleHeight - 1; y > 0; y--)
        {
            for (int x = 0; x < consoleWidth; x++)
            {
                Rocks[y, x] = Rocks[y - 1, x];
            }
        }
    }

    static void drawNewRow() //draws the top row of rocks that is coming from above
    {
        int y = 0, x = 0;
        int countRocks = RandRange(rocksPerRowMin, rocksPerRowMax); //random number of rocks that will attempt to be drawn on the row

        //Clear the top row
        for (x = 0; x < consoleWidth; x++)
        {
            Rocks[0, x].rockSymbol = '\0';
        }

        while (countRocks > 0)
        {
            if (rocksCurrentCount > rocksMaxOnField) { break; } //if we reached the limit of allowed rocks on the game field, then stop adding rocks

            do
            {

                x = RandRange(0, consoleWidth - 1);

            } while (Rocks[y, x].rockSymbol != 0x0);

            Rocks[y, x].rockSymbol = rockForms[RandRange(0, rockForms.Length - 1)];
            Rocks[y, x].rockColor = rockColors[RandRange(0, rockColors.Length - 1)];

            rocksCurrentCount++;
            countRocks--;
        }
    }

    static void ConsoleWriteEx(ref string str, char symbol, int x, int y, ConsoleColor color) //ConsoleWriteExtended, to save some lines of code
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;

        if (str != null)
        {
            Console.Write(str);
        }
        else
        {
            Console.Write(symbol);
        }

        Console.ResetColor();
    }

    static int RandRange(int minimumValue, int maximumValue) //Random number generator, Random() is not enough random ;)
    {
        byte[] randomNumber = new byte[1];

        rand.GetBytes(randomNumber);

        double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

        // We are using Math.Max, and substracting 0.00000000001,
        // to ensure "multiplier" will always be between 0.0 and .99999999999
        // Otherwise, it's possible for it to be "1", which causes problems in our rounding.

        double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

        // We need to add one to the range, to allow for the rounding done with Math.Floor

        int range = maximumValue - minimumValue + 1;
        double randomValueInRange = Math.Floor(multiplier * range);

        return (int)(minimumValue + randomValueInRange);
    }
}