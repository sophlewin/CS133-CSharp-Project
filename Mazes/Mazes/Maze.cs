using System;

namespace Mazes
{
    abstract class Maze
    {
        //Represents collection of cells that form a maze. Abstract - implemented by subclasses with different maze generation algorithms

        public Cell[,] grid { get; protected set; } //public getter accessed by Program & Player, protected setter accesssed by subclasses
        protected Random rnd = new Random(); //currently only used in BinaryTree, in parent class so could be used in other algorithms if developed further

        private int _rows; //private backing fields
        private int _columns;
        public int Rows
        {
            get { return _rows;}
            set
            {
                if (value > 0 && value < 21) //reasonable size to fit on screen
                {
                    _rows = value;
                }
                else
                {
                    Console.WriteLine("Number not in range");
                    _rows = 6; //6x6 grid by default
                }
            }
        }
        public int Columns
        {
            get { return _columns; }
            set
            {
                if (value > 0 && value < 21)
                {
                    _columns = value;
                }
                else
                {
                    Console.WriteLine("Number not in range");
                    _columns = 6; 
                }
            }
        }

        public Maze()
        {
            //Initialise grid
            Console.WriteLine("Enter number of rows to generate (1-20): ");
            Rows = Convert.ToInt32(Console.ReadLine()); //could add error handling for non-int inputs
            Console.WriteLine("Enter number of columns to generate (1-20): ");
            Columns = Convert.ToInt32(Console.ReadLine());

            grid = new Cell[Rows, Columns];
            for (int i = 0; i<Rows; i++) //Can't use foreach loop - can't assign to foreach iteration variables
            {
                for(int j = 0; j<Columns; j++)
                {
                    grid[i, j] = new Cell();
                }
            }
            grid[0, 0].hasPlayer = true;
        }

        public virtual Cell[,] Generate(Cell c)
        {
            return grid;
            //override in subclasses with different generation algorithms
        }

        public void Display()
        {
            //Output maze to console using text representations of cells
            Console.Clear();
            for(int a = 0; a<Columns*2; a++)
            {
                Console.Write("_"); //top wall
            }
            Console.Write("\n");
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(grid[i, j].Display());
                }
                Console.Write("|\n"); //right wall

            }
        }
    }
}
