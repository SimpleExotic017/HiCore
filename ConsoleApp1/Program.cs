using HiCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputFilter input = new InputFilter();
            input.Man();
            //string questions = input.QuestionToString("Do you have any questions for me?");
            //int favoriteNumber = input.QuestionToInt("What's your favorite number");
            //string favoriteColor = input.QuestionToString("What's your favorite Color");
            //string favoriteCat = input.QuestionToString("What's your favorite Cat's name");
            //Console.WriteLine($"you said \"{questions}\" When I asked you if you had questions\nyour favorite Number is \"{favoriteNumber}\"\nyour favorite Color is \"{favoriteColor}\"\nyour favorite Cat is \"{favoriteCat}\"\n");
        }
    }
}
