using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    
    public class GameLoop : Manager<GameLoop>
    {
        public bool isOver = false;
        public Creator creator = new Creator();
        public void Awake() // 시작
        {
            Setting.Instance.SetWindow();
            Input.Instance.KeyPosition();
        }
        public void Start()
        {
            creator.InitTile();
            creator.CreateMine();
            creator.cal.InitCal();
            creator.SetObject();
        }
        public void Update() // 그리기
        {
            while(!isOver)
            {
                creator.RenderAll(); // 그리기
                Input.Instance.GetKey(); // 입력
            }
        }
    }
}
