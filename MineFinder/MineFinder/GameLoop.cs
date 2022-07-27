using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    
    public class GameLoop : Manager<GameLoop>
    {
        public bool isOver = false; // 게임오버 확인
        public Creator creator = new Creator();
        public void Awake() // 시작
        {
            Setting.Instance.SetWindow(); // 윈도우 설정
            Input.Instance.KeyPosition(); // 초기 커서 위치 설정
        }
        public void Start()
        {
            creator.InitTile(); // 타일 초기화
            creator.CreateMine(); // 지뢰 생성
            creator.cal.InitCal(); // 숫자 계산
            creator.SetObject(); // 계산 결과를 저장
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
