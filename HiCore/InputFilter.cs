using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class InputFilter
    {
        private bool firstError = true;
        public void Man()
        {
            string[,] methodsAndDescription =
            {
                {
                    "TyposToInt",
                    "filters any typos regarding accidental shift-key releases on an azerty keyboard",
                },
                {
                    "QuestionToString",
                    "return a 'string' from user input in the console, you can set a custom question",
                },
                {
                    "QuestionToInt",
                    "return an 'int' from user input in the console, you can set a custom question",
                },
                {
                    "QuestionToLong",
                    "return a 'long' from user input in the console, you can set a custom question",
                },
            };
            Manual manual = new Manual();
            manual.PrintManual("InputFilter", methodsAndDescription);
        }

        public int TyposToInt(string input, bool inputIsNullSafety = false)
        {
            input = input.Replace("&", "1");
            input = input.Replace("é", "2");
            input = input.Replace("\"", "3");
            input = input.Replace("\'", "4");
            input = input.Replace("(", "5");
            input = input.Replace("§", "6");
            input = input.Replace("è", "7");
            input = input.Replace("!", "8");
            input = input.Replace("ç", "9");
            input = input.Replace("à", "0");
            if (input == "" && inputIsNullSafety)
            {
                input = "-1";
            }
            return Convert.ToInt32(input);
        }


        private static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public string QuestionToString(string question, bool errorDisplay = true)
        {
            Console.Write($"{question} : ");
            string input = Console.ReadLine();
            string returnValue = "";
            if (input == "")
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionToString(question, errorDisplay);
            }
            else
            {
                returnValue = input;
                firstError = true;
            }
            return returnValue;
        }

        public int QuestionToInt(string question, bool errorDisplay = true)
        {
            Console.Write($"{question} : ");
            string input = Console.ReadLine();
            int returnValue = 0;
            if (input == "")
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionToInt(question, errorDisplay);
            }
            else
            {
                try
                {
                    returnValue = Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    if (errorDisplay)
                    {
                        ErrorMessage(question);
                    }
                    returnValue = QuestionToInt(question, errorDisplay);
                    throw;
                }

            }
            return returnValue;
        }

        public long QuestionToLong(string question, bool errorDisplay = true)
        {
            Console.Write($"{question} : ");
            string input = Console.ReadLine();
            long returnValue = 0;
            if (input == "")
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionToLong(question, errorDisplay);
            }
            else
            {
                try
                {
                    returnValue = Convert.ToInt64(input);
                }
                catch (FormatException)
                {
                    if (errorDisplay)
                    {
                        ErrorMessage(question);
                    }
                    returnValue = QuestionToLong(question, errorDisplay);
                    throw;
                }
            }
            return returnValue;
        }

        private void ErrorMessage(string errorMessage = "")
        {
            ClearCurrentConsoleLine();
            if (firstError == true)
            {
                ConsoleColor resetColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input Invalid");
                Console.ForegroundColor = resetColor;
            }
            firstError = false;
        }
    }
}
