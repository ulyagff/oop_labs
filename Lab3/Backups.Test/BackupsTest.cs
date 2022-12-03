using System.IO.Compression;
using Backups.Repository;
using Backups.StorageAlgorithm;
using Xunit;
using Zio;
using Zio.FileSystems;

namespace Backups.Test;

public class BackupsTest
{
    [Fact]
    public void BackupTaskSplitAlgorithm()
    {
        var fileSystem = new MemoryFileSystem();
        fileSystem.CreateDirectory("/home/runner/work/ulyagff/task1/folder1");
        fileSystem.CreateDirectory("/home/runner/work/ulyagff/task1/Backups");

        using Stream fileA = fileSystem.CreateFile("/home/runner/work/ulyagff/task1/folder1/fileA");
        using Stream fileB = fileSystem.CreateFile("/home/runner/work/ulyagff/task1/folder1/fileB");
        fileA.Close();
        fileB.Close();

        var repoPath = new Path.Path("/home/runner/work/ulyagff/task1/");
        var repository = new InMemoryRepository(fileSystem, repoPath);
        var algorithm = new SingleStorageAlgorithm();
        var archivePath = new Path.Path("/Backups");
        var archiver = new Archiver.Archiver(repository);

        var backupTask = new BackupTask.BackupTask(repository, algorithm, archiver, archivePath);
        BackupObject.BackupObject obj1 = new BackupObject.BackupObject(repository, new Path.Path("folder1/fileA"));
        backupTask.AddBackupObject(obj1);
        backupTask.AddBackupObject(new BackupObject.BackupObject(repository, new Path.Path("folder1/fileB")));
        backupTask.Run();
        Assert.Equal(2, backupTask.Backup.BackupHistory.Last().Storage.ReturnRepoObjects().Count());
        backupTask.RemoveBackupObject(obj1);
    }
}