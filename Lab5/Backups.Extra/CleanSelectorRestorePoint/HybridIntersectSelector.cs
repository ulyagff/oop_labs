using Backups.BackupTask;
using Backups.Extra.CleanerRestorePoint;

namespace Backups.Extra.CleanSelectorRestorePoint;

public class HybridIntersectSelector : ICleanSelector
{
    private readonly List<ICleanSelector> _selectors;

    public HybridIntersectSelector(List<ICleanSelector> selectors)
    {
        _selectors = selectors;
    }

    public IReadOnlyCollection<RestorePoint> SelectObjects(IBackup backup)
    {
        int countCriterion = _selectors.Count;
        return _selectors
            .SelectMany(i => i.SelectObjects(backup))
            .GroupBy(i => i)
            .Where(i => i.Count() == countCriterion)
            .Select(i => i.Key)
            .Distinct()
            .ToList();
    }
}