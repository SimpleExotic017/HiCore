using HiCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputFilter input = new InputFilter();
            //input.Man();
            Logger logOut = new Logger();
            logOut.Succes();
            string[] names = { "DO NOT PRESS THIS BUTTON" };
            Action[] methods = { () => logOut.Error("are you dumb?") };
            new MethodPicker().Menu(names,methods);
        }
    }
}
