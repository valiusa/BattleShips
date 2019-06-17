using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Ship
    {
        public static int posX;
        public static int posY;

        public Ship(int _posX = 0, int _posY = 0)
        {
            posX = _posX;
            posY = _posY;
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
        private static int GetRandomPosition(int min = 0, int max = 0)
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
        public void AddBattleShip(char[,] map, int posX, int posY, int size)
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

        public void AddCruiser(char[,] map, int posX, int posY, int size)
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

        public void AddDestroyer(char[,] map, int posX, int posY, int size)
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

        public void AddSubmarine(char[,] map, int posX, int posY, int size)
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
