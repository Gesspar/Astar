﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Node
    {
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public enum enumType { Grass, Wall, Tree }
        public string Type { get; set; }

        public int ValF { get; set; }
        public int ValH { get; set; }
        public int ValG { get; set; }
        public int Cost { get; set; }
        public bool IsTraversable { get; set; }
        public List<Node> Connections { get; set; }
        public Node Parent { get; set; }

        public Node(string name, int posX, int posY)
        {
            IsTraversable = true;
            PositionX = posX;
            PositionY = posY;
            Name = name;
        }

        public void Draw(bool isSelected)
        {
            
            switch (Name)
            {
                case "Start":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "End":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            if (isSelected)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else { Console.ForegroundColor = ConsoleColor.Gray; }

            Console.Write(" G ");
        }

        public void Connect(Node[,] grid)
        {
            Connections = new List<Node>();

            for (int i = PositionY - 1; i < PositionY + 2; i++)
            {
                for (int k = PositionX - 1; k < PositionX + 2; k++)
                {
                    try
                    {
                        if (i != 0 && k != 0 && IsTraversable)
                        {
                            Connections.Add(grid[i, k]);
                        }
                    }
                    catch {
                    }
                }
            }


            for (int i = 0; i < Connections.Count; i++)
            {
                if ((i == 0 || i == 2 || i == 4 || i == 6) && Connections[i] != null)
                {
                    Connections[i].ValG = 14;
                }
                else if (Connections[i] != null)
                {
                    Connections[i].ValG = 10;
                }
            }

        }

    }
}
