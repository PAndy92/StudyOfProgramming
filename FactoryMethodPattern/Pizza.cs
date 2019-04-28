using System;
namespace Fatory
{
    // 주문 가능한 피자 타입들
    public enum PizzaType
    {
        Cheeze,
        Bulgogi,
        Vegetable,
        Sosauge
    }

    // 추상 클래스
    public abstract class Pizza
    {
        protected string pizzaName = "";
        protected int cost = 0;

        public void PrintPizza()
        {
            Console.WriteLine("Pizza Name : " + pizzaName + " // Pizza Cost : " + cost);
        }
    }

    // 도미노 피자
    public class DominoCheezePizza : Pizza
    {
        public DominoCheezePizza()
        {
            pizzaName = "DominoCheezePizza";
            cost = 20;
        }
    }

    public class DominoBulgogiPizza : Pizza
    {
        public DominoBulgogiPizza()
        {
            pizzaName = "DominoBulgogiPizza";
            cost = 30;
        }
    }

    public class DominoVegetablePizza : Pizza
    {
        public DominoVegetablePizza()
        {
            pizzaName = "DominoVegetablePizza";
            cost = 40;
        }
    }

    public class DominoSosaugePizza : Pizza
    {
        public DominoSosaugePizza()
        {
            pizzaName = "DominoSosaugePizza";
            cost = 15;
        }
    }

    // 미스터 피
    public class MrCheezePizza : Pizza
    {
        public MrCheezePizza()
        {
            pizzaName = "MrCheezePizza";
            cost = 15;
        }
    }

    public class MrBulgogiPizza : Pizza
    {
        public MrBulgogiPizza()
        {
            pizzaName = "MrBulgogiPizza";
            cost = 40;
        }
    }

    public class MrVegetablePizza : Pizza
    {
        public MrVegetablePizza()
        {
            pizzaName = "MrVegetablePizza";
            cost = 18;
        }
    }

    public class MrSosaugePizza : Pizza
    {
        public MrSosaugePizza()
        {
            pizzaName = "MrSosaugePizza";
            cost = 36;
        }
    }
}
