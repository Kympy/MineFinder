using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Mine // 지뢰
    {
        public int X;
        public int Y;
        public bool isOpen = false; // 열렸는지?

        public Mine()
        {
            X = 0;
            Y = 0;
            isOpen = false;
        }
    }
}
