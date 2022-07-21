using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Calculate
    {
        private int upX;
        private int upY;

        private int upLeftX;
        private int upLeftY;

        private int upRightX;
        private int upRightY;

        private int downX;
        private int downY;

        private int downLeftX;
        private int downLeftY;

        private int downRightX;
        private int downRightY;

        private int leftX;
        private int leftY;

        private int rightX;
        private int rightY;
        private Mine[] mine;

        private int row;
        private int col;

        public Calculate()
        {
            row = Setting.Instance.GetRow();
            col = Setting.Instance.GetCol();
        }
        private void CalculatePos(int x , int y)
        {
            upX = x; // x 가 열이동
            upY = y - 1; // y 가 행이동

            upLeftX = x - 1;
            upLeftY = y - 1;

            upRightX = x + 1;
            upRightY = y - 1;

            downX = x;
            downY = y + 1;

            downLeftX = x - 1;
            downLeftY = y + 1;

            downRightX = x + 1;
            downRightY = y + 1;

            leftX = x - 1;
            leftY = y;

            rightX = x + 1;
            rightY = y;
        }
        public int CalculateNum(int x, int y)
        {
            CalculatePos(x, y);
            int count = 0;
            for (int i = 0; i < GameLoop.Instance.creator.MineCount; i++)
            {
                if (mine[i].X == upX && mine[i].Y == upY) count++;
                else if (mine[i].X == upLeftX && mine[i].Y == upLeftY) count++;
                else if (mine[i].X == upRightX && mine[i].Y == upRightY) count++;
                else if (mine[i].X == downX && mine[i].Y == downY) count++;
                else if (mine[i].X == downLeftX && mine[i].Y == downLeftY) count++;
                else if (mine[i].X == downRightX && mine[i].Y == downRightY) count++;
                else if (mine[i].X == leftX && mine[i].Y == leftY) count++;
                else if (mine[i].X == rightX && mine[i].Y == rightY) count++;
            }
            return count;
         }
        public void OpenRange(int x, int y)
        {
            if(!(x >= 0 && y >= 0 && x < row && y < col) || GameLoop.Instance.creator.tile[x, y].isOpen) // 범위를 벗어나면 & 이미 열린 타일이면
            {
                return;
            }
            else if(GameLoop.Instance.creator.tile[x, y].isMine) // 지뢰면
            {
                GameLoop.Instance.creator.tile[x, y].isOpen = true; // 까고 리턴
                return;
            }
            else if (CalculateNum(x, y) > 0) // 숫자면
            {
                GameLoop.Instance.creator.tile[x, y].isOpen = true; // 까고 리턴
                return;
            }
            else if(CalculateNum(x, y) == 0) // 0 이면
            {
                GameLoop.Instance.creator.tile[x, y].isOpen = true; // 까고
                OpenRange(x, y - 1); // 좌
                OpenRange(x, y + 1); // 우
                OpenRange(x - 1, y); // 위
                OpenRange(x + 1, y); // 아래
                OpenRange(x - 1, y - 1); //대각
                OpenRange(x - 1, y + 1);
                OpenRange(x + 1, y - 1);
                OpenRange(x + 1, y + 1);
            }
            return;
        }
        public void InitCal()
        {
            mine = GameLoop.Instance.creator.mine;
        }
        private bool IsIn(int x, int y)
        {
            if (x >= 0 && x < row && y >= 0 && y < col)
            {
                return true;
            }
            return false;
        }
    }
}
