namespace Backups.Extra.Logger;

public class ConsoleLogger : ILogger
{
    public void PrintInformation(string information)
    {
        Console.WriteLine(information);
        Console.WriteLine();
    }

    public void PrintInformationAndTime(string information)
    {
        Console.WriteLine(DateTime.Now.ToString());
        Console.WriteLine(information);
        Console.WriteLine();
    }
}