using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Input : Manager<Input>
    {
        private int currentX;
        public int GetX() { return currentX; }
        private int currentY;
        public int GetY() { return currentY; }

        private int row;
        private int col;
        ConsoleKeyInfo key;
        public void KeyPosition()
        {
            currentX = Setting.Instance.GetRow() / 2;
            currentY = Setting.Instance.GetCol() / 2;
            row = Setting.Instance.GetRow();
            col = Setting.Instance.GetCol();
        }
        public void GetKey()
        {
            //if (Console.KeyAvailable) // 키입력이 존재한다면
            //{
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.RightArrow)
                {
                    currentY++;
                    if (currentY > col - 1) currentY = col - 1;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    currentY--;
                    if (currentY < 0) currentY = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    currentX--;
                    if (currentX < 0) currentX = 0;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    currentX++;
                    if (currentX > row - 1) currentX = row - 1;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    GameLoop.Instance.creator.cal.OpenRange(currentX, currentY);
                }
            //}
        }
    }
}
