using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Pathfinder
    {
        private List<Node> openList = new List<Node>();
        private List<Node> closedList = new List<Node>();
        private Node current;
        int q = 0;


        public Pathfinder(Node start, Node end, Grid grid)
        {
            Console.WriteLine("Start");
            openList.Add(start);
            start.ValH = Pythagoras(start.PositionX, start.PositionY, end.PositionX, end.PositionY);
            start.ValG = 0;
            start.ValF = start.ValH;
            while (openList != null)
            {
                current = SmallestNumber(openList);

                //Console.WriteLine("Connect");

                if (current == end)
                {
                    Console.WriteLine("Found End");
                    break;
                }

                current.Connect(grid.position);
                if (current.Connections.Contains(end))
                {
                    break;
                }
                foreach (Node successor in current.Connections)
                {
                    current.ValG = current.ValG + Distance(current.PositionX, current.PositionY, successor.PositionX, successor.PositionY);

                    if (openList.Contains(successor))
                    {
                        if (successor.ValG <= current.ValG)
                        {
                            continue;
                        }
                    }
                    else if (closedList.Contains(successor))
                    {
                        if (successor.ValG <= current.ValG)
                        {
                            openList.Add(successor);
                            closedList.Remove(successor);
                            continue;
                        }
                    }
                    else
                    {
                        openList.Add(successor);
                        successor.ValH = Pythagoras(successor.PositionX, successor.PositionY, end.PositionX, end.PositionY);
                    }

                    successor.ValG = current.ValG;
                    successor.Parent = current;
                }

                closedList.Add(current);
                openList.Remove(current);
                //Console.WriteLine("["+q+"]");


                foreach (Node item in grid.position)
                {

                    if (q == 10)
                    {
                        Console.WriteLine();
                        q = 0;
                    }
                    item.Draw(current == item);
                    q++;
                }
                Console.ReadKey();
                Console.WriteLine("Press anykey to continue to next step of the A* Loop.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                //openList.Remove(current);
            }
            if (current != end) { Console.Write("ERROR: The OPEN list is Empty"); }
        }

        private int Pythagoras(int x, int y, int x2, int y2)
        {
            int result;

            result = (-x + -y) + x2 + y2;
            //int a, b;
            //double c;
            //a = -x + x2;
            //double liftedA = a ^ 2;
            //b = -y + y2;
            //double liftedB = b ^ 2;
            //c = Math.Sqrt(liftedA) + Math.Sqrt(liftedB);

            //result = Convert.ToInt32(c);

            return result;
        }
        private int Distance(int x, int y, int x2, int y2)
        {
            int result;
            result = -x + -y + x2 + y2;


            return result;
        }

        public Node SmallestNumber(List<Node> numberToFind)
        {
            Node smallest = numberToFind[0];

            for (int i = 0; i > numberToFind.Count; i++)
            {
                if (smallest.ValF > numberToFind[i].ValF)
                {
                    smallest = numberToFind[i];
                }
            }
            return smallest;
        }

    }
}
