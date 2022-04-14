using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazes
{
    class ComputerPlayer:Player
    {
        //Type of Player which is controlled by computer

        private List<int> directions = new List<int>() {0, 1, 2, 3};
        private int lastDirection;
        private int oppositeDirection;

        public ComputerPlayer() : base()
        {
            lastDirection = 2;
            oppositeDirection = 0; //starts from (0, 0) - shouldn't try up first
        }

        public override void Move(Maze maze)
        {
            //NOTE: very ineffective algorithm - should ideally implement own recursive backtracking algorithm

            oppositeDirection = (lastDirection - 2 > -1) ? (lastDirection - 2) : (lastDirection + 2); //numeric directions so opposite can be found by +ing/-ing 2
            directions.Remove(oppositeDirection);
            directions = directions.OrderBy(a => Guid.NewGuid()).ToList(); //shuffle list so directions tried in random order
            directions.Add(oppositeDirection); //direction just came from should be last direction to try        

            int originalX = coordinates[1];
            int originalY = coordinates[0];

            foreach(int d in directions)
            {
                switch (d)
                {
                    case (0):
                        MoveUp(maze);
                        break;
                    case (1):
                        MoveLeft(maze);
                        break;
                    case (2):
                        MoveDown(maze);
                        break;
                    case (3):
                        MoveRight(maze);
                        break;
                }

                if ((coordinates[1] != originalX) || (coordinates[0] != originalY)) //coordinates changed - move was successful
                {
                    lastDirection = d; 
                    break; //no need to try other directions
                }

            }
            base.Move(maze); //after move, handles non-direction specific elements (display etc)
        }

    }
}
