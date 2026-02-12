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
                    "return a 'string' from user input in the console, you can set a custom question. An Error message will be displayed if the user's input is empty",
                },
                {
                    "QuestionToInt",
                    "return an 'int' from user input in the console, you can set a custom question. An Error message will be displayed if the user's input can not be converted to an int",
                },
                {
                    "QuestionToLong",
                    "return a 'long' from user input in the console, you can set a custom question. An Error message will be displayed if the user's input can not be converted to a long",
                },
                {
                    "QuestionYN",
                    "returns true when the user enters \"Y\" and returns false when \"N\".The user can not enter any other value (except if lowercase)",
                },
            };
            Manual manual = new Manual();
            manual.PrintManual("InputFilter", methodsAndDescription);
        }

        public int TyposToInt(string input, bool inputIsNullSafety = false)
        {
            int returnValue;
            try
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
                returnValue = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                returnValue = -1;
                throw;
            }
            return returnValue;
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
                RemoveErrorMessage(question, input);
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
            try
            {
                returnValue = Convert.ToInt32(input);
                RemoveErrorMessage(question, input);
            }
            catch
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionToInt(question, errorDisplay);
            }
            firstError = true;
            return returnValue;
        }

        public long QuestionToLong(string question, bool errorDisplay = true)
        {
            Console.Write($"{question} : ");
            string input = Console.ReadLine();
            long returnValue = 0;
            try
            {
                returnValue = Convert.ToInt64(input);
                RemoveErrorMessage(question, input);
            }
            catch
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionToInt(question, errorDisplay);
            }
            firstError = true;
            return returnValue;
        }

        public bool QuestionYN(string question, bool errorDisplay = true)
        {
            Console.Write($"{question} [Y/N] : ");
            string input = Console.ReadLine();
            bool returnValue = false;

            if (input.ToUpper() == "Y")
            {
                returnValue = true;
                RemoveErrorMessage(question + " [Y/N]", "Yes");
            }
            else if (input.ToUpper() == "N")
            {
                returnValue = false;
                RemoveErrorMessage(question + " [Y/N]", "No");
            }
            else
            {
                if (errorDisplay)
                {
                    ErrorMessage(question);
                }
                returnValue = QuestionYN(question, errorDisplay);
            }

            firstError = true;
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

        private void RemoveErrorMessage(string question, string value)
        {
            ClearCurrentConsoleLine();
            if (!firstError)
            {
                ClearCurrentConsoleLine();
            }
            Console.WriteLine($"{question} : {value}");
        }
    }
}
