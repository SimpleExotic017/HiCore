using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class MethodPicker
    {
        public static bool AllowLoadScreen = true;
        public static bool AllowLetterByLetter = true;

        public void Man()
        {
            string[,] methodsAndDescription =
            {
                {
                    "Menu",
                    "Displays a welcome to OOP message, shows the user all the method"
                        + " names they can choose from in a neat menu and takes their input to"
                        + " invoke the selected Method (this is a QOL method for my experience"
                        + " at Artesis Plantijn)",
                },
            };
            Manual manual = new Manual();
            manual.PrintManual("Menu", methodsAndDescription);
        }

        public void Menu(string[] methodNames, Action[] methods, bool validOption = true)
        {
            Console.Clear();
            ConsoleColor mainColor = ConsoleColor.DarkCyan;
            ConsoleColor listColor = ConsoleColor.Gray;
            ConsoleColor unfinishedColor = ConsoleColor.Red;
            ConsoleColor errorColor = ConsoleColor.Red;
            ConsoleColor adminCommands = ConsoleColor.Magenta;
            ConsoleColor inputColor = ConsoleColor.Yellow;
            ConsoleColor returnColor = ConsoleColor.White;

            WelcomeMessage(mainColor);
            PrintMethodList(methodNames, unfinishedColor, listColor);

            PrintAdminCommands(validOption, adminCommands, errorColor, mainColor);
            int choice = checkInputForCommands(inputColor);

            invokeMethodAndLoopBack(methodNames, methods, choice, returnColor, inputColor);
        }

        private void invokeMethodAndLoopBack(
            string[] methodNames,
            Action[] methods,
            int choice,
            ConsoleColor returnColor,
            ConsoleColor inputColor
        )
        {
            bool exit = false;
            if (choice == 0)
            {
                exit = true;
            }
            else if (choice > 0 && choice <= methods.Length)
            {
                if (AllowLoadScreen)
                {
                    LoadScreen();
                }
                methods[choice - 1].Invoke();
                Console.ForegroundColor = returnColor;
                Console.WriteLine("\nPRESS ENTER TO RETURN");
                Console.ForegroundColor = inputColor;
                Console.ReadLine();
            }
            else if (choice == -10) { }
            else
            {
                exit = true;
                Menu(methodNames, methods, false);
            }
            if (!exit)
            {
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
            Console.CursorVisible = false;
            int percentage = 0;
            string loading = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒";
            string finished = "████████████████████";
            Console.WriteLine($"Loading Excercise\n");

            Console.Write($"{loading} 0%");
            Thread.Sleep(500);
            for (int i = 0; i < 100; i++)
            {
                percentage++;
                if (i == 99)
                {
                    percentage = 100;
                    Thread.Sleep(892);
                }
                Console.SetCursorPosition(loading.Length, Console.CursorTop);
                Console.Write($" {percentage}%");
                if (i < 40)
                {
                    Thread.Sleep(40);
                }
                else if (i < 80)
                {
                    Thread.Sleep(60);
                }
                else if (i < 95)
                {
                    Thread.Sleep(180);
                }
                else
                {
                    Thread.Sleep(360);
                }
                if (i % 5 == 0)
                {
                    Console.SetCursorPosition(i / 5, Console.CursorTop);
                    Console.Write("█");
                }
            }
            ClearCurrentConsoleLine();
            ClearCurrentConsoleLine();
            new Logger().Succes("Loading Complete\n");
            Console.WriteLine($"{finished} 100%\n");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            for (int i = 0; i < 6; i++)
            {
                ClearCurrentConsoleLine();
            }
            Console.CursorVisible = true;
        }

        private void WelcomeMessage(ConsoleColor mainColor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\tWelcome to OOP");
            Console.WriteLine("\t\t**************");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\tList of classes");
            Console.WriteLine("");
        }

        private void PrintMethodList(
            string[] methodNames,
            ConsoleColor unfinishedColor,
            ConsoleColor listColor
        )
        {
            for (int i = 0; i < methodNames.Length; i++)
            {
                if (methodNames[i].Contains("(unfinished)"))
                {
                    Console.ForegroundColor = unfinishedColor;
                }
                else
                {
                    Console.ForegroundColor = listColor;
                }
                Console.WriteLine($"\tID {(i + 1)}: {methodNames[i]}\n");
            }
        }

        private void PrintAdminCommands(
            bool validOption,
            ConsoleColor adminCommands,
            ConsoleColor errorColor,
            ConsoleColor mainColor
        )
        {
            if (!MethodPicker.AllowLoadScreen)
            {
                Console.ForegroundColor = adminCommands;
                Console.WriteLine("\tno load enabled");
            }
            if (!validOption)
            {
                Console.ForegroundColor = errorColor;
                Console.Write("\tplease enter a valid methodID : ");
            }
            else
            {
                Console.ForegroundColor = mainColor;
                Console.Write("\tplease enter the methodID : ");
            }
        }

        private int checkInputForCommands(ConsoleColor inputColor)
        {
            Console.ForegroundColor = inputColor;
            string input = Console.ReadLine();
            int choice = -1;
            if (input == "no load")
            {
                MethodPicker.AllowLoadScreen = !MethodPicker.AllowLoadScreen;
                choice = -10;
            }
            else
            {
                if (!input.Contains("-"))
                {
                    choice = new InputFilter().TyposToInt(input, true);
                }
            }
            Console.Clear();
            return choice;
        }
    }
}
