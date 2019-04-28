using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    // 관찰 주체 인터페이스.
    interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notify();
    }

    // 관찰자 인터페이스.
    interface IObserver
    {
        void UpdateState();
    }

    /// <summary>
    /// Game manager. 상태 변화되는 주체 상태 변경 시. 등록된 관찰자들에게 통지해줌.
    /// </summary>
    class GameManager : ISubject
    {
        public DateTime gamePlayTime;

        // 등록된 옵저버 리스트.
        public List<IObserver> obList;

        public void AddObserver(IObserver observer)
        {
            obList.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            obList.Remove(observer);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }


        // 반복호출. 시간에 따라 게임 시간 변경.
        public void Update()
        {
             gamePlayTime = gamePlayTime.AddSeconds(1f);

            // 상태 변경 시. 등록된 Observer에 통지.
            if(gamePlayTime.Second > 30f)
            {
                
            }
        }
    }

    class PlayerUI : IObserver
    {
        public PlayerUI(GameManager gameManager)
        {
            gameManager.AddObserver(this);
        }

        public void UpdateState()
        {
            Console.WriteLine("게임 시간 30초 경과 했습니다.");
        }
    }

    class Player : IObserver
    {
        public Player(GameManager gameManager)
        {
            gameManager.AddObserver(this);
        }

        public void UpdateState()
        {
            Console.WriteLine("게임 시간 30초 경과 방어력 하락");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 테스트 코드
            GameManager gameManager = new GameManager();

            // Observer 객체 생성.
            PlayerUI playerUI = new PlayerUI(gameManager);
            Player player = new Player(gameManager);

            int count = 0;

            while(count < 31)
            {
                gameManager.Update();
                count++;
            }
        }
    }
}
