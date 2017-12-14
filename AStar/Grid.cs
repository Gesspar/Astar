using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Grid
    {
        internal Node[,] position;

        public Grid()
        {
            position = new Node[10, 10];
        }

    }
}
