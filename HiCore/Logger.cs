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

        public void Info(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[info] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }

        public void Trace(string message) {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[Trace] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Warning(string message) {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[Warning] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Error(string message) {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[Error] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Succes(string message) {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Succes] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }

    }
}
