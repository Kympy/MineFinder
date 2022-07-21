using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Creator
    {
        public Tile[,] tile;
        public int MineCount = 80;
        private int currentMineCount;
        public Mine[] mine;
        private Random rand = new Random();
        public Calculate cal = new Calculate();
        private int row;
        private int col;
        public Creator()
        {
            row = Setting.Instance.GetRow();
            col = Setting.Instance.GetCol();
            tile = new Tile[row, col];
            mine = new Mine[MineCount];
        }
        public void InitTile()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tile[i, j] = new Tile();
                    tile[i, j].X = i;
                    tile[i, j].Y = j;
                    tile[i, j].isOpen = false;
                }
            }
        }
        public void CreateMine()
        {
            for(int k = 0; k < MineCount; k++)
            {
                mine[k] = new Mine();
            }
            //int i = 0; // 카운트
            //bool isSolo = true; // 중복없는 수 인지?
            int q;
            for(q = 0; q < MineCount; q++)
            {
                mine[q].X = rand.Next(0, row);
                mine[q].Y = rand.Next(0, col);
                for(int p = 0; p < q; p++)
                {
                    if (mine[p].X == mine[q].X && mine[p].Y == mine[q].Y)
                    {
                        q--;
                        break;
                    }
                }
            }
            /*
            while (i < MineCount) // 지뢰 갯수 만큼
            {
                mine[i].X = rand.Next(0, row); // 열

                for (int j = 0; j < i; j++)
                {
                    if (mine[j].X == mine[i].X) // 이전거와 같은게 있다면
                    {
                        isSolo = false; // 중복임
                        break; // 브레이크
                    }
                }
                if (isSolo) // 중복없다면
                {
                    mine[i].Y = rand.Next(0, col); // 행
                    i++; // 다음 수
                }
                isSolo = true; // 초기화
            }
            */
        }
        public void SetObject()
        {
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    switch(cal.CalculateNum(i, j))
                    {
                        case 0:
                            {
                                tile[i, j].myShape = '□';
                                break;
                            }
                        case 1:
                            {
                                tile[i, j].myShape = '①';
                                break;
                            }
                        case 2:
                            {
                                tile[i, j].myShape = '②';
                                break;
                            }
                        case 3:
                            {
                                tile[i, j].myShape = '③';
                                break;
                            }
                        case 4:
                            {
                                tile[i, j].myShape = '④';
                                break;
                            }
                        case 5:
                            {
                                tile[i, j].myShape = '⑤';
                                break;
                            }
                        case 6:
                            {
                                tile[i, j].myShape = '⑥';
                                break;
                            }
                        case 7:
                            {
                                tile[i, j].myShape = '⑦';
                                break;
                            }
                        case 8:
                            {
                                tile[i, j].myShape = '⑧';
                                break;
                            }
                    }
                    for (int k = 0; k < MineCount; k++)
                    {
                        if (i == mine[k].X && j == mine[k].Y)
                        {
                            tile[i, j].myShape = '◈';
                            tile[i, j].isMine = true;
                        }
                    }
                }
            }
        }
        public void RenderAll()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
            CheckMineCount();
            Console.WriteLine("Left Mine : " + currentMineCount);
            Console.WriteLine();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (tile[i, j].myShape == '◈')
                    {
                        if(isCurrent(i, j) == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        if (tile[i, j].isOpen)
                        {
                            for(int k = 0; k < MineCount; k++)
                            {
                                if (i == mine[k].X && j == mine[k].Y)
                                {
                                    mine[k].isOpen = true;
                                }
                            }
                            if(isCurrent(i, j) == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(tile[i, j].myShape);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(tile[i, j].myShape);
                            }
                        }
                        else Console.Write(tile[i, j].hideShape);
                    }
                    else
                    {
                        if (isCurrent(i, j) == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        if (tile[i, j].isOpen)
                        {
                            Console.Write(tile[i, j].myShape);
                        }
                        else Console.Write(tile[i, j].hideShape);
                    }
                }
                Console.WriteLine();
            }
        }
        public void CheckMineCount()
        {
            int count = 0;
            for(int i = 0; i < MineCount; i++)
            {
                if(!mine[i].isOpen)
                {
                    count++;
                }
            }
            currentMineCount = count;
        }
        public bool isCurrent(int i, int j)
        {
            if (i == Input.Instance.GetX() && j == Input.Instance.GetY()) return true;
            else return false;
        }
    }
}
