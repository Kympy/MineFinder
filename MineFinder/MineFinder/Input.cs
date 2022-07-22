using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Input : Manager<Input>
    {
        private int currentX; // 현재 좌표
        public int GetX() { return currentX; }
        private int currentY;
        public int GetY() { return currentY; }

        private int row; // 행길이
        private int col; // 열길이
        ConsoleKeyInfo key; // 키
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
                if(key.Key == ConsoleKey.RightArrow) // 우측
                {
                    currentY++;
                    if (currentY > col - 1) currentY = col - 1;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    currentY--;
                    if (currentY < 0) currentY = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow) // 위
                {
                    currentX--;
                    if (currentX < 0) currentX = 0;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    currentX++;
                    if (currentX > row - 1) currentX = row - 1;
                }
                else if(key.Key == ConsoleKey.Enter) // 입력
                {
                    GameLoop.Instance.creator.cal.OpenRange(currentX, currentY);
                }
            //}
        }
    }
}
