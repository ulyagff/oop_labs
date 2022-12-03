using Backups.BackupTask;
using Backups.Extra.CleanerRestorePoint;

namespace Backups.Extra.CleanSelectorRestorePoint;

public class HybridUnionCleanSelector : ICleanSelector
{
    private readonly List<ICleanSelector> _selectors;
    public HybridUnionCleanSelector(List<ICleanSelector> selectors)
    {
        _selectors = selectors;
    }

    public IReadOnlyCollection<RestorePoint> SelectObjects(IBackup backup)
    {
        return _selectors
            .SelectMany(i => i.SelectObjects(backup))
            .Distinct()
            .ToList();
    }
}