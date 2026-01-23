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
            Print("Info", message, ConsoleColor.Blue);
        }

        public void Debug(string variable)
        {
            Print("Debug", variable, ConsoleColor.Red);
        }

        public void Trace(string message)
        {
            Print("Trace", message, ConsoleColor.Magenta);
        }

        public void Warning(string message)
        {
            Print("Warning", message, ConsoleColor.DarkYellow);
        }

        public void Error(string message)
        {
            Print("Error", message, ConsoleColor.DarkRed);
        }

        public void Succes(string message = "executed succesfully")
        {
            Print("Succes", message, ConsoleColor.Green);
        }

        private void Print(string errorType, string message, ConsoleColor fgColor)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = fgColor;
            Console.Write($"[{errorType}] ");
            Console.ForegroundColor = originalColor;
            Console.Write($"{message}\n");
        }
    }
}
