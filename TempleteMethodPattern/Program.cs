using System;
using System.Collections.Generic;

namespace TempleteSort
{
    class MainClass
    {
        /// <summary>
        /// Templete Method Pattern 서브 클래스에서 알고리즘 군을 구현하여 사용.
        /// </summary>
        class CustomCollector<T>
        {
            List<T> collector = new List<T>();

            public void AddItem(T item)
            {
                collector.Add(item);
            }

            /// <summary>
            /// 클래스의 타입에 따라 정렬 한다.
            /// </summary>
            public void SortAndPrint()
            {
                if(collector.Count == 0 || collector == null)
                {
                    Console.WriteLine("Empty Collector");
                    return;
                }

                // IComparable<T> 인터페이스를 이용하여 정렬한다.
                collector.Sort();

                foreach(T item in collector)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        /// <summary>
        /// Monster. 공격력 순으로 정렬 함.
        /// </summary>
        class Monster : IComparable<Monster>
        {
            public int defense;
            public int attack;

            public Monster(int atk, int def)
            {
                attack = atk;
                defense = def;
            }

            // Monster Tostring Override
            public override string ToString()
            {
                return base.ToString() + "// Attack : " + attack + " // Defense : " + defense;
            }

            // Monsters는 attack의 값으로 정렬
            int IComparable<Monster>.CompareTo(Monster other)
            {
                return this.attack >= other.attack ? 1 : -1;
            }
        }

        /// <summary>
        /// Animals. Size 순으로 정렬.
        /// </summary>
        class Animals : IComparable<Animals>
        {
            public string name;
            public int size;

            public Animals(string name, int size)
            {
                this.name = name;
                this.size = size;
            }

            // Animals은 Size순으로 정렬
            public int CompareTo(Animals other)
            {
                return this.size >= other.size ? 1 : -1;
            }

            // Animals Tostring Override
            public override string ToString()
            {
                return base.ToString() + "// name : " + name + " // size : " + size;
            }
        }

        public static void Main(string[] args)
        {

            List<Monster> mons = new List<Monster>();
            mons.Add(new Monster(1, 3));
            mons.Add(new Monster(5, 3));
            mons.Add(new Monster(3, 3));

            mons.Sort(new Monster(1,3) as IComparer<Monster>);

            // Monster Collector 생성
            CustomCollector<Monster> monsters = new CustomCollector<Monster>();
            
            // 몬스터 생성 추가
            monsters.AddItem(new Monster(1, 3));
            monsters.AddItem(new Monster(5, 3));
            monsters.AddItem(new Monster(3, 3));
            monsters.AddItem(new Monster(4, 3));
            monsters.AddItem(new Monster(6, 3));
            monsters.AddItem(new Monster(7, 3));
            monsters.AddItem(new Monster(9, 3));
            monsters.AddItem(new Monster(8, 3));

            monsters.SortAndPrint();

            // Animal Collector 생성
            CustomCollector<Animals> animals = new CustomCollector<Animals>();

            // 동물 생성 추가
            animals.AddItem(new Animals("기린", 20));
            animals.AddItem(new Animals("코끼리", 50));
            animals.AddItem(new Animals("사자", 10));
            animals.AddItem(new Animals("코뿔소", 30));
            animals.AddItem(new Animals("하마", 40));

            animals.SortAndPrint();
        }
    }
}
