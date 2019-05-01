using System;

namespace StateEx
{
    // State Pattern
    // FSM 유한 상태 정의. 현재 상태와 전이에 대해 정의 해야함.
    // 여러 상태를 추상화하고 공통적인 인터페이스 정의
    abstract class State
    {
        public enum StateType
        {
            NONECOIN, // 동전 없음
            HASCOIN, // 동전 있음
            SOLD, // 판매 및 동전 소모
            SOLDOUT // 매진
        }

        protected GumballMachine machine;

        // 동작은 추상 함수로 정의. 
        public abstract void InsertCoin();
        public abstract void ReturnCoin();
        public abstract void PlayGatcha();
        public abstract void Dispense();
    }

    // 동전없음 상태
    class NoneCoinState : State
    {
        public NoneCoinState(GumballMachine machine)
        {
            this.machine = machine;
        }

        public override void Dispense()
        {
            Console.WriteLine("동전을 넣어주세요");
        }

        // 동전 없는 상태는 동전 넣을 때만 동작 수행.
        public override void InsertCoin()
        {
            Console.WriteLine("동전을 들어왔습니다. 동전있는 상태로 변경 됩니다");
            machine.SetState(StateType.HASCOIN);
        }

        public override void PlayGatcha()
        {
            Console.WriteLine("동전을 넣어주세요");
        }

        public override void ReturnCoin()
        {
            Console.WriteLine("동전을 넣어주세요");
        }
    }

    // 동전있음 상태
    class HasCoinState : State
    {
        public HasCoinState(GumballMachine machine)
        {
            this.machine = machine;
        }

        public override void Dispense()
        {
            Console.WriteLine("레버를 돌리거나 동전 반환해주세요");
        }

        public override void InsertCoin()
        {
            Console.WriteLine("레버를 돌리거나 동전 반환해주세요");
        }

        public override void PlayGatcha()
        {
            Console.WriteLine("레버를 돌렸습니. 판매 산태로 변경됩니다.");
            machine.SetState(StateType.SOLD);
        }

        public override void ReturnCoin()
        {
            Console.WriteLine("동전이 반환됩니. 동전없음 상태로 변경됩니다.");
            machine.SetState(StateType.NONECOIN);
        }
    }

    // 판매상태
    class SoldState : State
    {
        public SoldState(GumballMachine machine)
        {
            this.machine = machine;
        }

        public override void Dispense()
        {
            // 껌볼 판매
            machine.ReleaeBall();

            // 껌볼 개수에 따라 판매매진 또는 동전 없음 상태로 변경.
            if (machine.GetGumBallCount() <= 0)
            {
                machine.SetState(StateType.SOLDOUT);
                Console.WriteLine("판매완료, 껌이 없어 매진 상태로 변경됩니다.");
            }
            else{
                machine.SetState(StateType.NONECOIN);
                Console.WriteLine("판매완료, 껌이 있어 동전없음 상태로 변경됩니다.");
               
            }

        }

        public override void InsertCoin()
        {
            Console.WriteLine("Dispense를 실행해주세요");
        }

        public override void PlayGatcha()
        {
            Console.WriteLine("Dispense를 실행해주세요");
        }

        public override void ReturnCoin()
        {
            Console.WriteLine("Dispense를 실행해주세요");
        }
    }

    // 판매완료 상태
    class SoldOutState : State
    {
        public SoldOutState(GumballMachine machine)
        {
            this.machine = machine;
        }

        public override void Dispense()
        {
            Console.WriteLine("매진");
        }

        public override void InsertCoin()
        {
            Console.WriteLine("매진");
        }

        public override void PlayGatcha()
        {
            Console.WriteLine("매진");
        }

        public override void ReturnCoin()
        {
            Console.WriteLine("매진");
        }
    }

    // StateMachine 동전을 넣고 레버를 돌리면 껌을 반환, 껌이 존재할 경우 계속 판매, 없을 경우 매진 상태로 변경
    class GumballMachine
    {
        State noneCoinState;
        State hasCoinState;
        State soldState;
        State soldOutState;

        // 현재 상태
        State currentState;

        // 껌 개수
        int gumCount;

        public GumballMachine()
        {
            noneCoinState = new NoneCoinState(this);
            hasCoinState = new HasCoinState(this);
            soldState = new SoldState(this);
            soldOutState = new SoldOutState(this);

            currentState = noneCoinState;
            gumCount = 10;
        }

        // 현재 상태를 변경해준다
        public void SetState(State.StateType type)
        {
            State state = noneCoinState;

            switch(type)
            {
                case State.StateType.NONECOIN:
                    state = noneCoinState;
                    break;
                case State.StateType.HASCOIN:
                    state = hasCoinState;
                    break;
                case State.StateType.SOLD:
                    state = soldState;
                    break;
                case State.StateType.SOLDOUT:
                    state = soldOutState;
                    break;
            }

            currentState = state;
        }

        // 코인 넣기
        public void InserteCoin()
        {
            currentState.InsertCoin();
        }

        // 코인 반환
        public void ReturnCoin()
        {
            currentState.ReturnCoin();
        }

        // 레버 돌리기
        public void PlayTrunk()
        {
            currentState.PlayGatcha();
            currentState.Dispense();
        }

        // 껌 개수 반환 함수 
        public int GetGumBallCount()
        {
            return gumCount;
        }

        // 껌 나오는 함수
        public void ReleaeBall()
        {
            Console.WriteLine("껌이 나왔습니다");
            if(gumCount != 0)
            {
                gumCount -= 1;
            }
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            // 껌볼 머신 생성
            GumballMachine machine = new GumballMachine();

            // 동전 없는 상태에서 레버를 돌릴 수 없음
            machine.InserteCoin();
            machine.ReturnCoin();
            machine.PlayTrunk();

            // 껌이 매진 될 때까지 동전 넣고 뽑는걸 반복한다 
            for (int i = 0; i < 11; i++)
            {
                machine.InserteCoin();
                machine.PlayTrunk();
            }
        }
    }
}
