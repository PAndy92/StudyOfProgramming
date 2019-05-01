using System;
using System.Collections.Generic;

namespace CommandPattern
{
    /// <summary>
    /// 커맨드 객체 캡슐화를 위한 인터페이스.
    /// </summary>
    interface Command
    {
        void Execute();
        void Undo();
    }

    class SkillA : Command
    {
        public void Execute()
        {
            Console.WriteLine("SkllA Use");
        }

        public void Undo()
        {
            Console.WriteLine("SkllA Cancel");
        }
    }

    class SkillB : Command
    {
        public void Execute()
        {
            Console.WriteLine("SkllB Use");
        }

        public void Undo()
        {
            Console.WriteLine("SkllB Cancel");
        }
    }

    class SkillC : Command
    {
        public void Execute()
        {
            Console.WriteLine("SkllC Use");
        }

        public void Undo()
        {
            Console.WriteLine("SkllC Cancel");
        }
    }

    /// <summary>
    /// Command contoller. 캡슐화 된 기능을 슬롯에 등록하여 사용 및 Redo, Undo를 위한 커맨드 리스트 관리.
    /// </summary>
    class CommandContoller
    {
        // 커맨드 슬롯 배열
        Command[] registedCommand;

        // 작업 수행 기록을 위한 리스트
        List<Command> workList;

        // 실행 취소, 다시 실행 인덱스
        int currentIndex = -1;

        public CommandContoller(int slotSize)
        {
            registedCommand = new Command[slotSize];
            workList = new List<Command>();
        }

        public void RegistCommand(Command command , int slot)
        {
            registedCommand[slot] = command;
        }

        // 슬롯 선택하면 커맨드 실행.
        public void PressCommand(int slot)
        {
            registedCommand[slot].Execute();

            // 최대 10개 까지 저장
            if(workList.Count == 10)
            {
                workList.RemoveAt(0);
                workList.TrimExcess();
            }

            // 실행한 커맨드는 저장해 둠
            workList.Add(registedCommand[slot]);
        }

        // 실행 취소
        public void Undo()
        {
            // 실행 취소 인덱스가 설정 되지 않으면. 맨 나중에 실행한 작업 인덱스로 설정
            if(currentIndex == -1)
            {
                currentIndex = workList.Count - 1;
            }

            if (currentIndex > -1)
                workList[currentIndex--].Undo();
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            CommandContoller ctrl = new CommandContoller(3);

            // 커맨드 등록
            ctrl.RegistCommand(new SkillA(), 0);
            ctrl.RegistCommand(new SkillB(), 1);
            ctrl.RegistCommand(new SkillC(), 2);

            // 커맨드 실행
            ctrl.PressCommand(0);
            ctrl.PressCommand(2);
            ctrl.PressCommand(1);

            // 커맨드 실행 취소
            ctrl.Undo();
            ctrl.Undo();
            ctrl.Undo();

        }
    }
}
