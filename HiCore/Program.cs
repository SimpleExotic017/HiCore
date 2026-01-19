namespace HiCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logOut = new Logger();
            string message = "this is just a message";
            logOut.Info(message);
            logOut.Debug(message);
            logOut.Trace(message);
            logOut.Warning(message);
            logOut.Error(message);
            logOut.Succes(message);

        }
    }
}
