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
        public static bool AllowLetterByLetter = false;
        public ConsoleColor welcomeColor = ConsoleColor.White;
        public ConsoleColor mainColor = ConsoleColor.DarkCyan;
        public ConsoleColor listColor = ConsoleColor.Gray;
        public ConsoleColor unfinishedColor = ConsoleColor.Red;
        public ConsoleColor errorColor = ConsoleColor.Red;
        public ConsoleColor adminCommands = ConsoleColor.Magenta;
        public ConsoleColor inputColor = ConsoleColor.Yellow;
        public ConsoleColor returnColor = ConsoleColor.White;

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

        public void Menu(
            string[] methodNames,
            Action[] methods,
            bool validOption = true,
            bool loadScreen = true
        )
        {
            Console.Clear();

            Console.CursorVisible = false;
            WelcomeMessage();
            PrintMethodList(methodNames);

            PrintAdminCommands(validOption);
            Console.CursorVisible = true;
            int choice = checkInputForCommands();

            invokeMethodAndLoopBack(methodNames, methods, choice, loadScreen);
        }

        private void invokeMethodAndLoopBack(
            string[] methodNames,
            Action[] methods,
            int choice,
            bool loadScreen
        )
        {
            bool exit = false;
            if (choice == 0)
            {
                exit = true;
            }
            else if (choice > 0 && choice <= methods.Length)
            {
                if (AllowLoadScreen && loadScreen)
                {
                    LoadScreen();
                }
                methods[choice - 1].Invoke();
                if (loadScreen)
                {
                    Console.ForegroundColor = returnColor;
                    Console.WriteLine("\nPRESS ENTER TO RETURN");
                    Console.ForegroundColor = inputColor;
                    Console.ReadLine();
                }
            }
            else if (choice == -10) { }
            else
            {
                exit = true;
                Menu(methodNames, methods, false, loadScreen);
            }
            if (!exit)
            {
                Menu(methodNames, methods, true, loadScreen);
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

        private void WelcomeMessage()
        {
            Console.ForegroundColor = welcomeColor;
            Console.WriteLine("\n\t\tWelcome to OOP");
            Console.WriteLine("\t\t**************");
            Console.WriteLine("");
            Console.ForegroundColor = mainColor;
            Console.WriteLine("\t\tList of classes");
            Console.WriteLine("");
        }

        private void PrintMethodList(string[] methodNames)
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
                PrintLetterByLetter($"\tID {(i + 1)}: {methodNames[i]}\n");
            }
        }

        private void PrintAdminCommands(bool inputIsValid)
        {
            List<string> orderOfCommands = new List<string>();
            int commandCount = 0;
            if (!AllowLoadScreen)
            {
                orderOfCommands.Add("\tnoload enabled");
                commandCount++;
            }
            if (!AllowLetterByLetter)
            {
                orderOfCommands.Add("\tprintnow enabled");
                commandCount++;
            }
            if (inputIsValid)
            {
                orderOfCommands.Add("\tplease enter the methodID : ");
            }
            else
            {
                orderOfCommands.Add("\tplease enter a valid methodID : ");
            }
            foreach (string command in orderOfCommands)
            {
                if (commandCount > 0)
                {
                    commandCount--;
                    Console.ForegroundColor = adminCommands;
                    PrintLetterByLetter(command);
                }
                else
                {
                    if (!inputIsValid)
                    {
                        Console.ForegroundColor = errorColor;
                        PrintLetterByLetter(command, false);
                    }
                    else
                    {
                        Console.ForegroundColor = mainColor;
                        PrintLetterByLetter(command, false);
                    }
                }
            }
        }

        public int checkInputForCommands()
        {
            Console.ForegroundColor = inputColor;
            string input = Console.ReadLine();
            int choice = -1;
            switch (input)
            {
                case "noload":
                    AllowLoadScreen = !AllowLoadScreen;
                    choice = -10;
                    break;
                case "printnow":
                    AllowLetterByLetter = !AllowLetterByLetter;
                    choice = -10;
                    break;
                case "ironlung":
                    IronLung();
                    choice = -10;
                    break;
                case "en -a":
                    AllowLetterByLetter = false;
                    AllowLoadScreen = false;
                    choice = -10;
                    break;
                case "dis -a":
                    AllowLetterByLetter = true;
                    AllowLoadScreen = true;
                    choice = -10;
                    break;
                default:
                    if (!input.Contains("-"))
                    {
                        choice = new InputFilter().TyposToInt(input, true);
                    }
                    break;
            }
            Console.Clear();
            return choice;
        }

        public static void IronLung()
        {
            Console.Clear();
            int slowDown = 1;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string text =
                "This is not an expedition. It is an execution. When they put you in here, they don’t want you to return. And even if you do, and even if they keep their promises… what freedom waits for you? A few dying ships in a sea of dead stars?\r\n\r\nIf there is still hope, it lies beyond the veil. Hope in this void is as illusionary as the starlight. I will choose to breathe my last at the bottom of an ocean, unseen, unheard, and uncontrolled.\r\n\r\nThey will get their execution.\r\n\r\nI will get my freedom.";
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text.Substring(i, 1));
                Thread.Sleep(20);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ReadLine();
            Console.CursorVisible = true;
        }

        public void PrintLetterByLetter(string sentence, bool nextLine = true)
        {
            if (AllowLetterByLetter)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    Console.Write($"{sentence}".Substring(i, 1));
                    Thread.Sleep(30);
                }
            }
            else
            {
                Console.Write($"{sentence}");
            }
            if (nextLine)
            {
                Console.Write("\n");
            }
        }
    }
}
