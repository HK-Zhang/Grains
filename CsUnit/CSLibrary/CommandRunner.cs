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

    public class SomeClassWithCtorArgs : IDisposable
    {
        public SomeClassWithCtorArgs(int arg1, string arg2)
        {
        }

        public void Dispose() { }
    }
}
