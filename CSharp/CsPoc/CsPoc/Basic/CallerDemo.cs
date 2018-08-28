using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    class CallerDemo
    {
        public void Execute()
        {
            var logger = new Logger();
            logger.TraceMessage("abc");
        }
    }

    public sealed class Logger
    {
        public void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }
    }
}
