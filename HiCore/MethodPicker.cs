using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class MethodPicker
    {
        public void Man()
        {
            string[,] methodsAndDescription =
            {
                {
                    "Menu",
                    "Displays a welcome message to OOP, shows the user all the method" +
                    " names they can choose from in a neat menu and takes their input to" +
                    " invoke the selected Method (this is a QOL method for my experience" +
                    " at Artesis Plantijn)",
                },
            };
            Manual manual = new Manual();
            manual.PrintManual("Menu", methodsAndDescription);
        }

        public void Menu(string[] methodNames, Action[] methods, bool validOption = true)
        {

            Console.Clear();
            Console.WriteLine("\n\t\tWelcome to OOP");
            Console.WriteLine("\t\t**************");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\tList of classes");
            Console.WriteLine("");
            for (int i = 0; i < methodNames.Length; i++)
            {
                if (methodNames[i].Contains("(unfinished)"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine($"\tID {i + 1}: {methodNames[i]}\n");
            }
            if (!validOption)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\tplease enter a valid methodID : ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\tplease enter the methodID : ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.Clear();
            bool exit = false;
            int choice = new InputFilter().TyposToInt(input, true);
            if (choice == 0)
            {
                exit = true;
            }
            else if (choice > 0 && choice <= methods.Length)
            {
                LoadScreen();
                methods[choice - 1].Invoke();
            }
            else
            {
                exit = true;
                Menu(methodNames, methods, false);
            }
            if (!exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPRESS ENTER TO RETURN");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ReadLine();
                Menu(methodNames, methods);
            }
        }

        private static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void LoadScreen()
        {
            int percentage = 0;
            string loading = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒";
            string finished = "████████████████████";
            Console.WriteLine($"Loading Excercise");
            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine(
                    $"{finished.Substring(0, i) + loading.Substring(i, 20 - i)} {percentage}%"
                );
                Thread.Sleep(15 * (i + 1));
                if (i == 20)
                {
                    Thread.Sleep(892);
                }
                ClearCurrentConsoleLine();
                if (i % 7 == 0)
                {
                    percentage += 7;
                }
                else if (i % 3 == 0)
                {
                    percentage += 4;
                }
                else if (i == 19)
                {
                    percentage += 4;
                }
                else
                {
                    percentage += 5;
                }
            }
            ClearCurrentConsoleLine();
            new Logger().Succes("Loading Complete");
            Console.WriteLine($"{finished} 100%\n");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                ClearCurrentConsoleLine();
            }
        }
    }
}
