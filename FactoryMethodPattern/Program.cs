using System;

namespace Fatory
{

    /// <summary>
    /// Pizza store. 피자가게 피자가게마다 피자 제조법은 다르다.
    /// Factory Method 패턴을 이용하여 객체 생성에 의존성이 낮아진다.
    /// </summary>
    abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaType type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.PrintPizza();

            return pizza;
        }

        protected abstract Pizza CreatePizza(PizzaType type);
    }

    /// <summary>
    /// Domino pizza. Domino 피자만 만든다
    /// </summary>
    class DominoPizza : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case PizzaType.Cheeze:
                    pizza = new DominoCheezePizza();
                    break;
                case PizzaType.Bulgogi:
                    pizza = new DominoBulgogiPizza();
                    break;
                case PizzaType.Vegetable:
                    pizza = new DominoVegetablePizza();
                    break;
                case PizzaType.Sosauge:
                    pizza = new DominoSosaugePizza();
                    break;
            }
            return pizza;
        }
    }

    /// <summary>
    /// Mr pizza. Mr 피자만 만든다
    /// </summary>
    class MrPizza : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case PizzaType.Cheeze:
                    pizza = new MrCheezePizza();
                    break;
                case PizzaType.Bulgogi:
                    pizza = new MrBulgogiPizza();
                    break;
                case PizzaType.Vegetable:
                    pizza = new MrVegetablePizza();
                    break;
                case PizzaType.Sosauge:
                    pizza = new MrSosaugePizza();
                    break;
            }
            return pizza;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 치즈 피자 주문
            PizzaType orderPizzaType = PizzaType.Cheeze;

            // DominoPizza 제작
            PizzaStore store = new DominoPizza();

            store.OrderPizza(orderPizzaType);

            // Mr 피자로 바꿔보기
            store = new MrPizza();
            store.OrderPizza(orderPizzaType);

            // 피자 타입 바꿔보기
            orderPizzaType = PizzaType.Bulgogi;
            store.OrderPizza(orderPizzaType);
        }
    }
}
