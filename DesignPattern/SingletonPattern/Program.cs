using System;

namespace SingletonPattern
{
    public class GameManager
    {
        // GameManager의 instances는 하나만 존재
        private static GameManager instance;
        private float gameTime;

        /// <summary>
        /// Gets the instance.
        /// 호출 순간 객체 생성이 되므로 객체 생성 순서에서 자유로워짐.
        /// 모든 클래스에서 GameManager 객체가 접근 가능.
        /// </summary>
        /// <returns>The instance.</returns>
        public static GameManager GetInstance()
        {
            if(instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }

        public float GetGameTime()
        {
            return gameTime;
        }

        public void AddTime(float tick)
        {
            gameTime += tick;
        }
    }

    class MonsterManager
    {
        public MonsterManager()
        {
            Console.WriteLine(GameManager.GetInstance().GetGameTime());
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 싱글톤 객체는 전역객체처럼 어디서든지 접근 가능. 
            GameManager.GetInstance().AddTime(1f);

            MonsterManager monsterManager = new MonsterManager();
        }
    }
}
