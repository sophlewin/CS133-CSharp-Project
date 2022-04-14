using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    class HumanPlayer:Player
    {
        //Type of Player which is controlled by keyboard input
        public HumanPlayer() : base()
        {

        }

        public override void Move(Maze maze)
        {
            //Take keyboard input, call appropriate method to move
            switch (Console.ReadKey().Key)
            {
                case (ConsoleKey.UpArrow):
                    MoveUp(maze);
                    break;
                case (ConsoleKey.LeftArrow):
                    MoveLeft(maze);
                    break;
                case (ConsoleKey.DownArrow):
                    MoveDown(maze);
                    break;
                case (ConsoleKey.RightArrow):
                    MoveRight(maze);
                    break;
            }
            base.Move(maze); //after move, handles non-direction specific elements (display etc)
        }
    }
}
