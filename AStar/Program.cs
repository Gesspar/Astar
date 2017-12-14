using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Program
    {
        //static private int[,] localPos;
        public static Grid grid;
        static private Pathfinder p;

        static void Main(string[] args)
        {
            grid = new Grid();
            //localPos = new int[grid.position.GetLength(0), grid.position.GetLength(1)];
            for (int i = 0; i < grid.position.GetLength(0); i++)
            {
                for (int j = 0; j < grid.position.GetLength(1); j++)
                {
                    grid.position[i,j] = new Node("["+i+","+j+"]",i,j);
                }
            }
            foreach (Node item in grid.position)
            {
                item.Connect(grid.position);
            }

            Node z = grid.position[0, 0];
            Node q = grid.position[9, 9];
            z.Name = "Start";
            q.Name = "End";


            p = new Pathfinder(z, q,grid);

            

            //Use for debuggin, prints out name of all nodes in the grid;
            /*
            for (int i = 0; i < grid.position.GetLength(0); i++)
            {
                for (int j = 0; j < grid.position.GetLength(1); j++)
                {
                    Console.Write(grid.position[i,j].Name);
                }
                Console.WriteLine();
            }
            */

            Console.ReadKey();
        }
    }
}
