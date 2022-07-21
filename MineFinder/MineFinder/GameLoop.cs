using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    
    public class GameLoop : Manager<GameLoop>
    {
        private long currentTick;
        private long lastTick = 0;
        private int frameRate = 15;
        private float waitTick = 0;

        public Creator creator = new Creator();
        public void Awake()
        {
            waitTick = 1000 / frameRate;
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
        public void Update()
        {
            while(true)
            {
                creator.RenderAll();
                Input.Instance.GetKey();
            }
            /*
            while(true)
            {
                currentTick = Environment.TickCount & Int32.MaxValue;
                if(currentTick - lastTick < waitTick)
                {
                    continue;
                }
                else
                {
                    lastTick = currentTick;
                    Input.Instance.GetKey();
                    creator.RenderAll();
                }
            }
            */
        }
    }
}
