namespace Backups.Extra.Logger;

public class FileLogger : ILogger
{
    private StreamWriter _log;

    public FileLogger(StreamWriter log)
    {
        _log = log;
    }

    public void PrintInformation(string information)
    {
        _log.WriteLine(information);
        _log.WriteLine();
    }

    public void PrintInformationAndTime(string information)
    {
        _log.WriteLine(DateTime.Now.ToString());
        _log.WriteLine(information);
        _log.WriteLine();
    }
}