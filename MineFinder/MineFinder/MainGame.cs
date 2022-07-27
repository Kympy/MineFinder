using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class MainGame
    {
        private static void Main()
        {
            GameLoop.Instance.Awake();
            GameLoop.Instance.Start();
            GameLoop.Instance.Update();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tGame Over"); // 겜오버 업데이트문 나오면
        }
    }
}
