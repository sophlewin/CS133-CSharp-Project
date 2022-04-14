using System;
using System.Collections.Generic;

namespace Mazes
{
    class Cell
    {
        //Represents individual cells that make up a maze

        public bool left { get; private set; } //represent walls - only 2 needed per cell in a grid layout
        public bool below { get; private set; } //public getters because accessed by Player to check move validity
       
        public bool hasPlayer {get; set; } //public fields - need to be accessed & modified by other classes
        public List<Cell> adjacentCells { get; set; }

        public Cell()
        {
            left = true;
            below = true;
            adjacentCells = new List<Cell>();
            hasPlayer = false;
        }

        public void Carve(int direction) 
        {
            //Remove a wall to create a passageway
            //Only 2 walls needed - eg to carve up, remove bottom wall of cell above
            switch (direction)
            {
                case 0:
                    below = false;
                    break;
                case 1:
                    left = false;
                    break;
                default:
                    throw new System.ArgumentException("Invalid argument passed", "direction");
            }
        }

        public string Display() 
        {
            //Returns string representation of cell to pass to Maze.Display()
            string symbol = "";
            if (hasPlayer)
            {
                symbol = "██"; //player symbol fills whole cell so walls visually irrelevant
            }
            else
            {
                if (left)
                {
                    symbol += '|';
                }
                else
                {
                    symbol += '_';
                }
                if (below)
                {
                    symbol += '_';
                }
                else
                {
                    symbol += ' '; //ensures even spacing
                }
            }
            return symbol;                     
        }

        public (int x, int y) FindIndex(Maze maze)
        {
            //Relate each cell to its geometric position in the maze by checking each index for a match
            for (int i = 0; i < maze.Rows; i++)
            {
                for (int j = 0; j < maze.Columns; j++)
                {
                    if (maze.grid[i, j] == this)
                    {
                        return (i, j);
                    }
                }
            }
            throw new System.ArgumentException("Argument does not contain this object", "maze"); //thrown if cell not found in maze
        }
    }
}
