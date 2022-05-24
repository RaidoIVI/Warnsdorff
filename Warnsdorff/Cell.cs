using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warnsdorff
{
    internal class Cell
    {
        internal readonly int x;
        internal readonly int y;
        internal int value;

        internal Cell (int x, int y)
        {
            this.x = x;
            this.y = y;
            value = 0;
        }

        
    }
}
