using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    class BinaryTree:Maze
    {
        //Type of maze generated using binary tree algorithm
        //NOTE: to allow coordinates to be in [x, y] form, y increases to the right and x increases downwards

        public BinaryTree() : base()
        {

        }

        public override Cell[,] Generate(Cell c)
        {
            //Algorithm to generate maze - from each cell, choose to go either left or down (south-west bias)
            foreach (Cell cell in grid)
            {
                //x increases downwards, y increases to the right
                int direction = rnd.Next(2); //0 or 1 - rnd declared in Maze
                if(cell.FindIndex(this).x==(Rows-1) && c.FindIndex(this).y ==(Columns-1))
                {
                    //bottom right corner - do nothing
                }
                else if(cell.FindIndex(this).x == (Rows-1))
                {
                    //downwards blocked - go left
                    cell.Carve(1);
                }
                else if(cell.FindIndex(this).y == 0 || direction == 0)
                {
                    //left blocked OR neither blocked but down chosen - go down
                    cell.Carve(0);
                }
                else
                {
                    //go left
                    cell.Carve(1);
                }
            }
            return grid;
        }

    }
}
