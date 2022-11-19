using Backups.Repository;
using Backups.StorageAlgorithm;
using Xunit;
using Zio;
using Zio.FileSystems;

namespace Backups.Test;

public class BackupsTest
{
    /*
    public BackupsTest()
    {
    }
    */
    [Fact]
    public void BackupTaskSplitAlgorithm()
    {
        var fileSystem = new MemoryFileSystem();
        fileSystem.CreateDirectory("/home/runner/work/ulyagff/task1/folder1");
        fileSystem.CreateDirectory("/home/runner/work/ulyagff/task1/Backups");

        using var fileA = fileSystem.CreateFile("/home/runner/work/ulyagff/task1/folder1/fileA");
        using var fileB = fileSystem.CreateFile("/home/runner/work/ulyagff/task1/folder1/fileB");
        fileA.Close();
        fileB.Close();

        var repository = new InMemoryRepository(fileSystem, "/home/runner/work/ulyagff/task1/");
        var algorithm = new SingleStorageAlgorithm();
        var archiver = new Archiver.Archiver(repository, "Backups");

        var backupTask = new BackupTask.BackupTask("task1", repository, algorithm, archiver);
        BackupObject.BackupObject obj1 = new BackupObject.BackupObject(repository, "folder1/fileA", "fileA");
        backupTask.AddBackupObject(obj1);
        backupTask.AddBackupObject(new BackupObject.BackupObject(repository, "folder1/fileB", "fileB"));
        backupTask.Run();
        backupTask.RemoveBackupObject(obj1);
        backupTask.Run();
        Assert.True(true);
    }
}