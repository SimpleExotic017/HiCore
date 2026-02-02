using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class Logger
    {
        public void Manual()
        {
            string[,] methodsAndDescription =
            {
                { "Info", "Logging function to display info in the console" },
                { "Debug", "Debugging function to display debug variables in the console" },
                { "Trace", "Tracing function to Trace variable Values and display them in the console" },
                { "Warning", "Warning function to display Warnings in the console" },
                { "Error", "Error function to display Errors in the console" },
                { "Succes", "Succes function to display a succes message in the console after task completion" },
            };
            Intro intro = new Intro("Logger",methodsAndDescription);
        }

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
