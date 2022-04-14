using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    abstract class Player
    {
        //Abstract class - HumanPlayer and ComputerPlayer inherit & implement

        public bool completedMaze { get; private set; } //public getter (accessed by Program) but only set from within this class
        protected int[] coordinates; //protected fields - all accessed by subclasses
        protected int moves;
        protected int x;
        protected int y;

        public Player()
        {
            completedMaze = false;
            coordinates = new int[2];
            coordinates[0] = 0;
            coordinates[1] = 0; //start at (0, 0)
            moves = 0;
            x = coordinates[0]; //shorter names - easier to reference
            y = coordinates[1]; 
        }

        private void Completed() //only called from this class
        {
            completedMaze = true; //bool checked by Program to break out of while loop
            Console.WriteLine("Congratulations, you completed the maze in {0} moves! Press any key to exit.", moves);
            Console.ReadKey(); //wait to exit
        }

        public virtual void Move(Maze maze)
        {
            //Overridden by subclasses (human input vs trial and error) but both call base() afterwards

            x = coordinates[0]; //set x & y to new coordinates for next move
            y = coordinates[1];

            maze.grid[coordinates[1], coordinates[0]].hasPlayer = true;
            maze.Display();
            moves++;
            Console.WriteLine("Moves: {0}", moves);           

            if ((coordinates[0] == (maze.Columns)-1) && (coordinates[1] == (maze.Rows-1))) //only 2 elements, easiest to check individually
            {
                //reached bottom right corner - completed maze
                Completed();
            }
        }

        protected void MoveUp(Maze maze) //only called from subclasses
        {
            //check in range of grid and not blocked by walls
            if ((y > 0) && (maze.grid)[y - 1, x].below == false) //&& - doesn't attempt to evaluate second condition if cell not in grid
            {
                coordinates[1]--;
                maze.grid[y, x].hasPlayer = false;
            }
        }

        protected void MoveLeft(Maze maze)
        {
            if ((x > 0) && (maze.grid[y, x].left == false))
            {
                coordinates[0]--;
                maze.grid[y, x].hasPlayer = false;
            }
        }

        protected void MoveDown(Maze maze)
        {
            if ((y < maze.Rows-1) && (maze.grid[y, x].below == false))
            {
                coordinates[1]++;
                maze.grid[y, x].hasPlayer = false;
            }
        }

        protected void MoveRight(Maze maze)
        {
            if ((x < maze.Columns-1) && (maze.grid[y, x + 1].left == false))
            {
                coordinates[0]++;
                maze.grid[y, x].hasPlayer = false;
            }
        }



    }
}
