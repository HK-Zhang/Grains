using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveTDD
{
    public interface ICommand : IDisposable
    {
        void Execute();
        event EventHandler Executed;
    }

    public class CommandRunner
    {
        private ICommand _command;

        public CommandRunner(ICommand command)
        {
            _command = command;
        }

        public void RunCommand()
        {
            _command.Execute();
            _command.Dispose();
        }
    }

    public class SomethingThatNeedsACommand
    {
        ICommand command;
        public SomethingThatNeedsACommand(ICommand command)
        {
            this.command = command;
        }
        public void DoSomething() { command.Execute(); }
        public void DontDoAnything() { }
    }


    public class SomeClassWithCtorArgs : IDisposable
    {
        public SomeClassWithCtorArgs(int arg1, string arg2)
        {
        }

        public void Dispose() { }
    }

    public class CommandRepeater
    {
        ICommand command;
        int numberOfTimesToCall;
        public CommandRepeater(ICommand command, int numberOfTimesToCall)
        {
            this.command = command;
            this.numberOfTimesToCall = numberOfTimesToCall;
        }

        public void Execute()
        {
            for (var i = 0; i < numberOfTimesToCall; i++) command.Execute();
        }
    }

    public class CommandWatcher
    {
        ICommand command;
        public CommandWatcher(ICommand command)
        {
            this.command = command;
            this.command.Executed += OnExecuted;
        }
        public bool DidStuff { get; private set; }
        public void OnExecuted(object o, EventArgs e)
        {
            DidStuff = true;
        }
    }

    public class OnceOffCommandRunner
    {
        ICommand command;
        public OnceOffCommandRunner(ICommand command)
        {
            this.command = command;
        }
        public void Run()
        {
            if (command == null) return;
            command.Execute();
            command = null;
        }
    }
}
