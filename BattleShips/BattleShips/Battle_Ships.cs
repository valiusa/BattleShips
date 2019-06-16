using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*                                    [Battle Ships]
   In Battleship, an armada of battleships is hidden in a square grid of 10×10 small squares.
   The armada includes one battleship four squares long, two cruisers three squares long, 
   three destroyers two squares long, and four submarines one square in size.
   Each ship occupies a number of contiguous squares on the grid, arranged horizontally or
   vertically. The ships are placed so that no ship touches any other ship, not even diagonally.
   
   The goal of the puzzle is to discover where the ships are located.A grid may start with clues in the
   form of squares that have already been solved, showing a submarine, an end piece of a ship, a middle
   piece of a ship, or water. Each row and column also has a number beside it, indicating the number of 
   squares occupied by ship parts in that row or column, respectively.
*/

namespace BattleShips
{
    class Battle_Ships
    {
        static void Main(string[] args)
        {
            Console.WriteLine("   [ bs => Battleship - 1 ]\n" + 
                              "   [ c  => Cruiser    - 2 ]\n" + 
                              "   [ d  => Destroyer  - 3 ]\n" +
                              "   [ s  => Submarine  - 4 ]");

            int size = 10;

            char[,] map = new char[size, size];

            ShowMap(map, size); // Show the empty map

            Console.Write("Pick ship: ");
            string ship = Console.ReadLine().ToLower();

            SetShipsOnMap(ship, map, size); // Place the ships on the map

            ShowMap(map, size); // Show the map with the picked ships
        }

        // Displays the map --------------------------------
        private static void ShowMap(char[,] map, int size)
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[{map[i, j]}]");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"[{map[i, j]}]");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"[{map[i, j]}]");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"[{map[i, j]}]");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.Write($"[{map[i, j]}]");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------");
        }

        // Sets the ships on the map ------------------------------------------
        private static void SetShipsOnMap(string ship, char[,] map, int size)
        {
            int posX = 0;
            int posY = 0;
            //int count = 0; // Count's the current size of the ship

            while (ship != "end")
            {
                switch (ship)
                {
                    case "bs":
                        // Battleship [Look: @ - Color: red]
                        AddBattleShip(map, posX, posY, size);

                        //Console.WriteLine("Battle_Ship");
                        break;
                    case "c":
                        // Cruiser [Look: # - Color: magenta]
                        AddCruiser(map, posX, posY, size);

                        //Console.WriteLine("Cruiser");
                        break;
                    case "d":
                        // Destroyer [Look: $ - Color blue]
                        AddDestroyer(map, posX, posY, size);

                        //Console.WriteLine("Destroyer");
                        break;
                    case "s":
                        // Submarine [Look: * - Color: yellow]
                        AddSubmarine(map, posX, posY, size);

                        //Console.WriteLine("Submarine");
                        break;
                    default:
                        break;
                }

                Console.Write("Pick ship: ");
                ship = Console.ReadLine().ToLower();
            }
        }

        // Check if the current space is free ----------------------------
        private static bool IsFreeSpace(char[,] map, int posX, int posY)
        {
            if (map[posX, posY] == '\0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Gets a random position to place the ship --------------------
        public static int GetRandomPosition(int min = 0, int max = 0)
        {
            Random rnd = new Random();
            int rand = rnd.Next(min, max);

            if (rand == 10)
            {
                rand--;
            }

            return rand;
        }

        // Check if there is enough space to put the ship on the map ------------------------------------------------
        private static string IsThereEnoughSpace(char[,] map, int posX, int posY, char pick, int shipSize, int size)
        {
            int countP = 0;
            int countM = 0;

            // Get the plus coord
            for (int p = 1; p <= shipSize; p++)
            {
                // Check if the "pick" variable is for horizontally or for vertically
                if (pick == 'x')
                {
                    if (posX + p < size) // Check if it's outside the bounderies of the array
                    {
                        if (IsFreeSpace(map, posX, posY)) // Check if the picked position is free
                        {
                            if (map[posX + p, posY] == '\0')
                            {
                                countP++;
                            }
                        }
                    }
                }
                else
                {
                    if (posY + p < size) // Check if it's outside the bounderies of the array
                    {
                        if (IsFreeSpace(map, posX, posY)) // Check if the picked position is free
                        {
                            if (map[posX, posY + p] == '\0')
                            {
                                countP++;
                            }
                        }
                        
                    }
                }
            }

            // Get the minus coord
            for (int m = shipSize; m >= 1; m--)
            {
                // Check if the "pick" variable is for horizontally or for vertically
                if (pick == 'x')
                {
                    if (posX - m > 0) // Check if it's outside the bounderies of the array
                    {
                        if (IsFreeSpace(map, posX, posY)) // Check if the picked position is free
                        {
                            if (map[posX - m, posY] == '\0')
                            {
                                countM++;
                            }
                        }                        
                    }                    
                }
                else
                {
                    if (posY - m > 0) // Check if it's outside the bounderies of the array
                    {
                        if (IsFreeSpace(map, posX, posY)) // Check if the picked position is free
                        {
                            if (map[posX, posY - m] == '\0')
                            {
                                countM++;
                            }
                        }                        
                    }
                }
            }

            if (countM == shipSize && countP == shipSize)
            {
                return "both";
            }
            else if (countM == shipSize && countP < shipSize)
            {
                return "minus";
            }
            else if (countM < shipSize && countP == shipSize)
            {
                return "plus";
            }
            else
            {
                return "neither";
            }
        }

        // Ship constructing --------------------------------------------------------
        public static void AddBattleShip(char[,] map, int posX, int posY, int size)
        {
            char[] x_y = { 'x', 'y' };
            char pick = x_y[GetRandomPosition(0, 2)];

            int bsSize = 4;

        pickPos:
            posX = GetRandomPosition(0, size);
            posY = GetRandomPosition(0, size);

            if (size >= bsSize)
            {
                string freePos = IsThereEnoughSpace(map, posX, posY, pick, bsSize, size);

                switch (pick)
                {
                    case 'x':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX + i, posY] = '@';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX + i, posY] = '@';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX - i, posY] = '@';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                    case 'y':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX, posY - i] = '@';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX, posY + i] = '@';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '@';
                            for (int i = 1; i < bsSize; i++)
                            {
                                map[posX, posY - i] = '@';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                }
                //Console.WriteLine("TEST");
            }
            else
            {
                Console.WriteLine("There is not enough space!");
            }
        }

        public static void AddCruiser(char[,] map, int posX, int posY, int size)
        {
            char[] x_y = { 'x', 'y' };
            char pick = x_y[GetRandomPosition(0, 2)];

            int cSize = 3;

        pickPos:
            posX = GetRandomPosition(0, size);
            posY = GetRandomPosition(0, size);

            if (size >= cSize)
            {
                string freePos = IsThereEnoughSpace(map, posX, posY, pick, cSize, size);

                switch (pick)
                {
                    case 'x':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX + i, posY] = '#';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX + i, posY] = '#';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX - i, posY] = '#';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                    case 'y':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX, posY - i] = '#';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX, posY + i] = '#';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '#';
                            for (int i = 1; i < cSize; i++)
                            {
                                map[posX, posY - i] = '#';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                }
                //Console.WriteLine("TEST");
            }
            else
            {
                Console.WriteLine("There is not enough space!");
            }
        }

        public static void AddDestroyer(char[,] map, int posX, int posY, int size)
        {
            char[] x_y = { 'x', 'y' };
            char pick = x_y[GetRandomPosition(0, 2)];

            int dSize = 2;

        pickPos:
            posX = GetRandomPosition(0, size);
            posY = GetRandomPosition(0, size);

            if (size >= dSize)
            {
                string freePos = IsThereEnoughSpace(map, posX, posY, pick, dSize, size);

                switch (pick)
                {
                    case 'x':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX + i, posY] = '$';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX + i, posY] = '$';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX - i, posY] = '$';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                    case 'y':
                        if (freePos == "both")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX, posY - i] = '$';
                            }
                        }
                        if (freePos == "plus")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX, posY + i] = '$';
                            }
                        }
                        if (freePos == "minus")
                        {
                            map[posX, posY] = '$';
                            for (int i = 1; i < dSize; i++)
                            {
                                map[posX, posY - i] = '$';
                            }
                        }
                        if (freePos == "neither")
                        {
                            goto pickPos;
                        }
                        break;
                }
                //Console.WriteLine("TEST");
            }
            else
            {
                Console.WriteLine("There is not enough space!");
            }
        }

        public static void AddSubmarine(char[,] map, int posX, int posY, int size)
        {
            posX = GetRandomPosition(0, size);
            posY = GetRandomPosition(0, size);

            while (map[posX, posY] != '\0')
            {
                posX = GetRandomPosition(0, size);
                posY = GetRandomPosition(0, size);
            }

            map[posX, posY] = '*';
        }
    }
}