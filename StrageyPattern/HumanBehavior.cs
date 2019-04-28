using System;
namespace Test
{
    // 공격 인터페이스
    interface AttackBehavior
    {
        void Attack();
    }

    class MeleeAttack : AttackBehavior
    {
        public void Attack()
        {
            Console.WriteLine("근접 공격");
        }
    }

    class HolyAttack : AttackBehavior
    {
        public void Attack()
        {
            Console.WriteLine("신성 공격");
        }
    }

    class NoneAttack : AttackBehavior
    {
        public void Attack()
        {
            Console.WriteLine("공격 불가");
        }
    }

    // 텔레포트 인터페이스
    interface TeleportBehavior
    {
        void Teleport();
    }

    class TeleportToTown : TeleportBehavior
    {
        public void Teleport()
        {
            Console.WriteLine("마을로 순간이동");
        }
    }
    class TeleportNone : TeleportBehavior
    {
        public void Teleport()
        {
            Console.WriteLine("순간이동 불가");
        }
    }

}
