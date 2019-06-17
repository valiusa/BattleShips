using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Map
    {
        public static int size = 0;

        public Map (int _size = 0)
        {
            size = _size;
        }

        // Displays the map --------------------------------
        public void ShowMap(char[,] map, int size)
        {
            Console.WriteLine("------------------------------");            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[{map[i, j]}]");
                        //Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"[{map[i, j]}]");
                        //Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"[{map[i, j]}]");
                        //Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"[{map[i, j]}]");
                        //Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{map[i, j]}]");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------");
        }

        // Sets the ships on the map ------------------------------------------
        public void SetShipsOnMap(char[,] map)
        {
            Ship ship = new Ship(0, 0);

            Console.Write("Pick ship: ");
            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                switch (command)
                {
                    case "bs":
                        // Battleship [Look: @ - Color: red]
                        ship.AddBattleShip(map, Ship.posX, Ship.posY, Map.size);

                        //Console.WriteLine("Battle_Ship");
                        break;
                    case "c":
                        // Cruiser [Look: # - Color: magenta]
                        ship.AddCruiser(map, Ship.posX, Ship.posY, Map.size);

                        //Console.WriteLine("Cruiser");
                        break;
                    case "d":
                        // Destroyer [Look: $ - Color blue]
                        ship.AddDestroyer(map, Ship.posX, Ship.posY, Map.size);

                        //Console.WriteLine("Destroyer");
                        break;
                    case "s":
                        // Submarine [Look: * - Color: yellow]
                        ship.AddSubmarine(map, Ship.posX, Ship.posY, Map.size);

                        //Console.WriteLine("Submarine");
                        break;
                    default:
                        break;
                }

                Console.Write("Pick ship: ");
                command = Console.ReadLine().ToLower();
            }
        }
    }
}
