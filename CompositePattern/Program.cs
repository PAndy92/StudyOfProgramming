using System;
using System.Collections.Generic;

namespace CompositeEx
{
    // 컴포지트 패턴 트리형 구조를 만드는데 적합
    class Component
    {
        // Root Componet
        Component root;

        string name;

        // Child Component List로 관리
        List<Component> childList = new List<Component>();

        // 등록할 컴포넌트에 자신을 부모로 설정 해줌.
        public void AddComponent(Component child)
        {
            child.SetParent(this);
            childList.Add(child);
        }

        public void RemoveComponent(Component child)
        {
            child.SetParent(null);
            childList.Remove(child);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach(Component child in childList)
            {
                // 해당 타입이 검색 되면 반환
                if(child.GetType() == typeof(T))
                {
                    return (T)child;
                }
            }

            return null;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        // 부모 컴포넌트 등록 
        public void SetParent(Component root)
        {
            this.root = root;
        }

        // 부모 컴포넌트 반환
        public Component GetParent()
        {
            return root;
        }

        // 해당 인덱스의 자식을 가져옴
        public Component GetChild(int i)
        {
            // 존재하지 않는 인덱스는 Null 반환
            if (i < 0 || i > childList.Count - 1)
                return null;

             return childList[i];
        }
    }

    class Transform : Component
    {
        float xPos , yPos, zPos;
           
        public void SetPos(float x, float y, float z)
        {
            xPos = x;
            yPos = y;
            zPos = z;

            Console.WriteLine("{0} 현재 위치 : {1}, {2}, {3} " , GetParent().GetName(), x,y,z);
        }
    }

    class Character : Component
    {
        public void Attack()
        {
            Console.WriteLine(GetParent().GetName() + "의 공격 !");
        }

        public void Item()
        {
            Console.WriteLine(GetParent().GetName() + "의 아이템 사용 !");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Component player = new Component();
            player.SetName("전사");

            // 플레이어에 필요한 Component 추가
            player.AddComponent(new Transform());
            player.AddComponent(new Character());

            // Playeer에 등록된 트랜스폼을 가져옴. 가져올 경우 특정 클래스로 지정해줘서 사용하도록 한다.
            player.GetComponent<Transform>().SetPos(10, 0 , 5);
            player.GetComponent<Character>().Attack();
            player.GetComponent<Character>().Item();

            Console.WriteLine("{0}컴포넌트의 {1}번째 자식 컴포넌트 : {2}", player.GetName(), 0, player.GetChild(0));
            Console.WriteLine("{0}컴포넌트의 {1}번째 자식 컴포넌트 : {2}", player.GetName(), 1, player.GetChild(1));

        }
    }
}
