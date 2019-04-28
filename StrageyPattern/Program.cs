using System;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Human. 클래스에 직접 인터페이스를 추가하지 않음으로 서브 클래스에 구현을 피할 수 있음.
    /// 또한 멤버 변수의 인터페이스를 가짐으로써 동적으로 인터페이스의 동작을 변경가능. -> Setter 함수들 확인.
    /// </summary>
    class Human
    {
        private AttackBehavior attackBehavior;
        private TeleportBehavior teleportBehavior;

        virtual protected void Display()
        {
            // 화면 렌더링.
        }

        public void Walk()
        {
            // 걷기
        }

        // AttackBehaviour의 인터페이스를 설정해줌.
        public void SetAttackBehavior(AttackBehavior behavior)
        {
            attackBehavior = behavior;
        }

        // TeleportBehaviour의 인터페이스를 설정해줌.
        public void SetTeleportBehavior(TeleportBehavior behavior)
        {
            teleportBehavior = behavior;
        }

        // 등록된 텔레포트 인터페이스 실행.
        public void PerformTeleport()
        {
            teleportBehavior.Teleport();
        }

        // 등록된 공격 인터페이스 실행.
        public void PerformAttack()
        {
            attackBehavior.Attack();
        }
    }

    class Fighter : Human
    {
        override protected void Display()
        {
            base.Display();
        }
    }

    class Priest : Human
    {
        override protected void Display()
        {
            base.Display();
        }
    }

    class NPC : Human
    {
        override protected void Display()
        {
            base.Display();
        }

    }

    class MainClass
    {
        // 테스트 코드 실행
        public static void Main(string[] args)
        {
            // 파이터 캐릭 생성 및 동작 추가
            Fighter fight = new Fighter();
            fight.SetAttackBehavior(new MeleeAttack());
            fight.SetTeleportBehavior(new TeleportToTown());

            fight.PerformAttack();

            // 사제 캐릭 생성 및 동작 추가
            Priest priest = new Priest();
            priest.SetAttackBehavior(new HolyAttack());
            priest.SetTeleportBehavior(new TeleportToTown());

            priest.PerformAttack();

            // Npc 캐릭 생성 및 동작 추가
            NPC npc = new NPC();
            npc.SetAttackBehavior(new NoneAttack());
            npc.SetTeleportBehavior(new TeleportNone());

            npc.PerformTeleport();
        }
    }
}
