using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Tile
    {
        public int X;
        public int Y;
        public bool isOpen = false;
        public char myShape;
        public char hideShape = '■';
        public bool isMine = false;
        public Tile()
        {

        }
    }
}
