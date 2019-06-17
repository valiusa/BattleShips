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
            ShowPicks();
            Map map = new Map(10);
            char[,] board = new char[Map.size, Map.size];

            map.ShowMap(board, Map.size);
            map.SetShipsOnMap(board);
            map.ShowMap(board, Map.size);
        }

        private static void ShowPicks()
        {
            Console.WriteLine("   [ bs => Battleship - 1 ]\n" +
                              "   [ c  => Cruiser    - 2 ]\n" +
                              "   [ d  => Destroyer  - 3 ]\n" +
                              "   [ s  => Submarine  - 4 ]\n" +
                              "   [ end => Pick end      ]");
        }
    }
}