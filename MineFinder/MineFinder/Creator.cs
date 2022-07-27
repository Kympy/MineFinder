using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Creator
    {
        public Tile[,] tile; // 타일
        public int MineCount = 80; // 지뢰 갯수
        private int currentMineCount; // 현재 남은 지뢰 갯수
        public Mine[] mine; // 지뢰
        private Random rand = new Random();
        public Calculate cal = new Calculate(); // 각종 계산
        private int row;
        private int col;
        public Creator()
        {
            row = Setting.Instance.GetRow();
            col = Setting.Instance.GetCol();
            tile = new Tile[row, col];
            mine = new Mine[MineCount];
        }
        public void InitTile() // 타일 초기화
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
        public void CreateMine() // 지뢰 중복 X 생성
        {
            for(int k = 0; k < MineCount; k++) // 지뢰 갯수만큼 메모리 할당
            {
                mine[k] = new Mine();
            }
            int q;
            for(q = 0; q < MineCount; q++) // q는 지뢰 갯수 만큼 돈다.
            {
                mine[q].X = rand.Next(0, row); // 랜덤한 위치 생성
                mine[q].Y = rand.Next(0, col);
                for(int p = 0; p < q; p++) // p 는 지금까지 생성한 지뢰갯수 만큼 돈다.
                {
                    if (mine[p].X == mine[q].X && mine[p].Y == mine[q].Y) // 만약 이전까지 지뢰좌표와
                    {                                                                                // 현재 지뢰좌표가 겹치면 다시 생성한다.
                        q--;
                        break;
                    }
                }
            }
        }
        public void SetObject() // 지뢰, 숫자 표시
        {
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    switch(cal.CalculateNum(i, j)) // 숫자면
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
                    for (int k = 0; k < MineCount; k++) // 지뢰면
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
        public void RenderAll() // 그리기
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
                    if (tile[i, j].myShape == '◈') // 지뢰면
                    {
                        if(isCurrent(i, j) == false) // 현재 선택중이면
                        {
                            Console.BackgroundColor = ConsoleColor.Black; // 색깔
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        if (tile[i, j].isOpen) // 타일이 열렸으면?
                        {
                            for(int k = 0; k < MineCount; k++)
                            {
                                if (i == mine[k].X && j == mine[k].Y)
                                {
                                    mine[k].isOpen = true;
                                }
                            }
                            if(isCurrent(i, j) == false) //현재 선택?
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
                        else Console.Write(tile[i, j].hideShape); // 안열리면 가리기
                    }
                    else // 지뢰가 아니면
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
        public void CheckMineCount() // 현재 지뢰갯수
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
        public bool isCurrent(int i, int j) // 현재 좌표
        {
            if (i == Input.Instance.GetX() && j == Input.Instance.GetY()) return true;
            else return false;
        }
    }
}
