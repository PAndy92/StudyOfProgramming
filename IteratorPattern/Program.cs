using System;
using System.Collections.Generic;

namespace IteratorEx
{
    class MainClass
    {
        // 메뉴 가격과 이름이 적혀 있음.
        class MenuItem
        {
            int cost;
            string name;

            public MenuItem(int cost, string name)
            {
                this.cost = cost;
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }

            public int GetCost()
            {
                return cost;
            }
        }

        abstract class Menu
        {
            public abstract Iterator<MenuItem> CreateIterator();
        }

        // 저녁 메뉴는 List로 관리중
        class DinnerMenu : Menu
        {
            List<MenuItem> menuList = new List<MenuItem>();

            public void AddItem(MenuItem item)
            {
                menuList.Add(item);
            }

            // List Iterator를 반환 
            public override Iterator<MenuItem> CreateIterator()
            {
                return new ListIterator<MenuItem>(menuList);
            }
        }

        // 런치 메뉴는 Dictionary로 관리중
        class LunchMenu : Menu
        {
            Dictionary<int, MenuItem> menuDictionary = new Dictionary<int, MenuItem>();

            public void AddItem(int key, MenuItem item)
            {
                menuDictionary.Add(key,item);
            }

            // Dictionary Iterator 반환
            public override Iterator<MenuItem> CreateIterator()
            {
                return new DictionaryIterator<int ,MenuItem>(menuDictionary);
            }
        }

        // 종업원은 Container Iterator만 받고 전체 순회
        class PartTimer
        {
            // Iterator를 받으면 전체 순회 해서 출력함.
            public static void AllPrintMenu(Iterator<MenuItem> iterator)
            {
                while(iterator.HasNext())
                {
                    MenuItem item = iterator.Next();
                    Console.WriteLine(" 메뉴 : " + item.GetName() + " // 가격 : " + item.GetCost());
                }
            }
        }

        public static void Main(string[] args)
        {
            // 점심 메뉴 생성 
            LunchMenu lunch = new LunchMenu();
            lunch.AddItem(0, new MenuItem(6000, "제육볶음"));
            lunch.AddItem(5, new MenuItem(7000, "불고기"));
            lunch.AddItem(3, new MenuItem(6500, "순두부 찌개"));

            // 저녁 메뉴 생성 
            DinnerMenu dinner = new DinnerMenu();
            dinner.AddItem(new MenuItem(15000, "닭발"));
            dinner.AddItem(new MenuItem(7000, "황도"));
            dinner.AddItem(new MenuItem(12000, "오뎅탕"));

            PartTimer.AllPrintMenu(lunch.CreateIterator());

            PartTimer.AllPrintMenu(dinner.CreateIterator());

        }
    }
}
