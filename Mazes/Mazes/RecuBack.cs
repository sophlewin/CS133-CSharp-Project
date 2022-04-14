using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazes
{
    class RecuBack:Maze
    {
        //Type of maze generated using recursive backtrack algorithm
        //NOTE: to allow coordinates to be in [x, y] form, y increases to the right and x increases downwards

        private List<Cell> visitedCells;
        
        public RecuBack() : base()
        {
            //initialises grid with cells
            visitedCells = new List<Cell>();
        }     

        public override Cell[,] Generate(Cell c)
        {
            //Algorithm to generate maze
            int x = c.FindIndex(this).x;
            int y = c.FindIndex(this).y;
            if (!visitedCells.Contains(grid[x, y]))
            {
                visitedCells.Add(grid[x, y]);
            }

            List<Cell> adjacentCells = grid[x, y].adjacentCells;

            //Check all 4 directions, if an adjacent cell exists in that direction (i.e. not on edge) add it to list as a possible path
            if (x > 0)
            {
                //up is fine
                grid[x, y].adjacentCells.Add(grid[x - 1, y]);
            }
            if (x < Rows-1)
            {
                //down is fine
                grid[x, y].adjacentCells.Add(grid[x + 1, y]);
            }
            if (y > 0)
            {
                //left is fine
                grid[x, y].adjacentCells.Add(grid[x, y-1]);
            }
            if (y < Columns-1)
            {
                //right is fine
                grid[x, y].adjacentCells.Add(grid[x, y+1]);
            }

            adjacentCells = adjacentCells.OrderBy(a => Guid.NewGuid()).ToList(); //shuffle list so directions tried in random order

            foreach (Cell cell in adjacentCells)
            {
                if (!visitedCells.Contains(cell))
                {
                    //not already visited - cell is valid
                    if (cell.FindIndex(this).Item1 > x)
                    {
                        grid[x, y].Carve(0); //carve downwards
                        Generate(grid[x + 1, y]); //call recursively with cell below
                    }
                    if (cell.FindIndex(this).Item1 < x)
                    {
                        grid[x - 1, y].Carve(0); //carve upwards
                        Generate(grid[x - 1, y]); //call recursively with cell above                    
                    }
                    if (cell.FindIndex(this).Item2 > y)
                    {
                        grid[x, y + 1].Carve(1); //carve right
                        Generate(grid[x, y+1]); //call recursively with cell to the right
                    }
                    if(cell.FindIndex(this).Item2<y)
                    {
                        grid[x, y].Carve(1); //carve left
                        Generate(grid[x, y-1]); //call recursively with cell to the left
                    }
                }             
            }
            return grid;
        }
      
    }
}
