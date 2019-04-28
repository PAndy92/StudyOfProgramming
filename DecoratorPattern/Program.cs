using System;

namespace Decorator
{
    /// <summary>
    /// 음료 부모 클래스.
    /// </summary>
    abstract class Beverage
    {
        protected string description;
        protected int cost;

        public abstract int getCost();

        public virtual string getDescription()
        {
            return description;
        }
    }

    // 베이스 음료.
    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            cost = 10;
            description = "DarkRoast";
        }

        public override int getCost()
        {
            return cost;
        }
    }

    // 베이스 음료.
    class ColdBrew : Beverage
    {
        public ColdBrew()
        {
            cost = 20;
            description = "ColdBrew";
        }

        public override int getCost()
        {
            return cost;
        }
    }

    /// <summary>
    /// 첨가물 클래스. 자바 헤드 퍼스트 책 설계를 따랐는데 C#에선 필요 없는거 같음.
    /// </summary>
    abstract class CondimentDecorator : Beverage
    {
        public override string getDescription()
        {
            return description;
        }
    }

    // 첨가물.
    class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override int getCost()
        {
            return 20 + beverage.getCost();
        }

        public override string getDescription()
        {
            return beverage.getDescription() + "Mocha";
        }

    }

    // 첨가물.
    class Soy : CondimentDecorator
    {
        Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override int getCost()
        {
            return 30 + beverage.getCost();
        }

        public override string getDescription()
        {
            return beverage.getDescription() + "Soy";
        }
    }



    class MainClass
    {
        public static void Main(string[] args)
        {
            // 베이스 음료를 선택하고 첨가물을 넣어주어. 동적으로 서브 클래스를 첨가해줌.
            // 좋은 구조인지는 솔직히 의문...
            Beverage coldbrewWithMochaSoy = new ColdBrew();
            coldbrewWithMochaSoy = new Mocha(coldbrewWithMochaSoy);
            coldbrewWithMochaSoy = new Soy(coldbrewWithMochaSoy);

            Console.Write(coldbrewWithMochaSoy.getCost());
            Console.Write(coldbrewWithMochaSoy.getDescription());
        }
    }
}
