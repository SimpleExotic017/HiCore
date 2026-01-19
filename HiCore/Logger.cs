using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    internal class Logger
    {
        public class logger() { }

        public void info(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[info] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }

        public void Trace() { }
        public void Warning() { }
        public void Error() { }
        public void Succes() { }

    }
}
