using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Setting : Manager<Setting>
    {
        private int Width = 40;
        public int GetWidth() { return Width; }

        private int Height = 20;
        public int GetHeight() { return Height; }

        private int Row = 20;
        public int GetRow() { return Row; }

        private int Col = 20;
        public int GetCol() { return Col; }

        public void SetWindow()
        {
            Console.SetWindowSize(Width, Height + 3);
            Console.BufferWidth = Width;
            Console.BufferHeight = Height + 3;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
        }
    }
}
