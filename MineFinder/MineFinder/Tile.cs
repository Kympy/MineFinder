using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Tile
    {
        public int X; // 좌표
        public int Y;
        public bool isOpen = false; // 깠는지
        public char myShape; // 내 모양
        public char hideShape = '■'; // 덮일 때 모양
        public bool isMine = false; // 지뢰인지?
        public Tile()
        {

        }
    }
}
