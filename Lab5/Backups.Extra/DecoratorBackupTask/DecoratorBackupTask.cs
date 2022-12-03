using Backups.BackupTask;
using Backups.Extra.Logger;

namespace Backups.Extra.DecoratorBackupTask;

public class DecoratorBackupTask : IBackupTask
{
    private ILogger _logger;
    private IBackupTask _decoratee;

    public DecoratorBackupTask(ILogger logger, IBackupTask decoratee)
    {
        _logger = logger;
        _decoratee = decoratee;
    }

    public void AddBackupObject(BackupObject.BackupObject backupObject)
    {
        _decoratee.AddBackupObject(backupObject);
        _logger.PrintInformation("Backup Object was added successfully");
    }

    public void RemoveBackupObject(BackupObject.BackupObject backupObject)
    {
        _decoratee.RemoveBackupObject(backupObject);
        _logger.PrintInformation("Backup Object was successfully deleted");
    }

    public void Run()
    {
        _decoratee.Run();
        _logger.PrintInformation("Backup completed successfully");
    }
}