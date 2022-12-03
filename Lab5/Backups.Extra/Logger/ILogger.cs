namespace Backups.Extra.Logger;

public interface ILogger
{
    public void PrintInformation(string information);
    public void PrintInformationAndTime(string information);
}