using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HumanPlayer myPlayer = new HumanPlayer();

            RecuBack myMaze = new RecuBack();

            myMaze.Generate(myMaze.grid[0, 0]);
            myMaze.Display();

            while (!myPlayer.completedMaze)
            {
                myPlayer.Move(myMaze);
            }

        }
    }
}
