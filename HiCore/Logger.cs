using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class Logger
    {

        public void Info(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[info] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }

        public void Debug(string variable)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Debug] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{variable}\n");
        }

        public void Trace(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[Trace] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Warning(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[Warning] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Error(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[Error] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
        public void Succes(string message = "executed succesfully")
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Succes] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
    }
}

