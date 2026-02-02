using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    internal class Intro
    {
        public ConsoleColor foreGroundColor = ConsoleColor.Yellow;
        public ConsoleColor methodsColor = ConsoleColor.DarkBlue;
        public ConsoleColor highLight = ConsoleColor.Blue;
        private string introWidth =
            "*****************************************************************";

        public Intro(string className, string[,] MethodsAndDescription)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = foreGroundColor;
            string[] logo =
            {
                @" _   _ _  ____  ",
                @"| | | (_)/ ___|___  _ __ ___",
                @"| |_| | | |   / _ \| '__/ _ \",
                @"|  _  | | |__| (_) | | |  __/",
                @"|_| |_|_|\____\___/|_|  \___|",
            };
            Console.Write("\n");
            for (int i = 0; i < logo.Length; i++)
            {
                Console.WriteLine($"\t\t\t{logo[i]}");
            }
            Console.WriteLine("\n\t\t\tWelcome to the HiCore Library");
            Console.WriteLine($"\n\t{introWidth}\n");
            //one tab is 8 characters long
            Console.Write("\t\t\t\tClass: ");
            Console.ForegroundColor = highLight;
            Console.WriteLine($"{className}\n");
            PrintClassFunctionalities(MethodsAndDescription);
            Console.ForegroundColor = defaultColor;
        }

        private void PrintClassFunctionalities(string[,] MethodsAndDescription)
        {
            for (int i = 0; i < MethodsAndDescription.GetLength(0); i++)
            {
                Console.ForegroundColor = methodsColor;
                Console.Write($"\t{MethodsAndDescription[i, 0].PadRight(10)}");
                Console.ForegroundColor = foreGroundColor;
                Console.Write($"| ");
                string[] description = MethodsAndDescription[i, 1].Split(" ");
                string descriptionLine = "";
                int counter = 1;
                for (int index = 0; index < description.Length; index++)
                {
                    if ((descriptionLine.Length + description[index].Length) < 50)
                    {
                        descriptionLine += description[index] + " ";
                    }
                    else if (counter == 1)
                    {
                        Console.WriteLine(descriptionLine);
                        descriptionLine = description[index] + " ";
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine(descriptionLine.PadLeft(descriptionLine.Length + 20));
                        descriptionLine = description[index] + " ";
                    }
                }

                if (counter == 1)
                {
                    Console.WriteLine(descriptionLine);
                }
                else
                {
                    Console.WriteLine(descriptionLine.PadLeft(descriptionLine.Length + 20));
                }
                Console.Write($"\n");
            }
        }
    }
}
