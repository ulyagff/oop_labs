using Isu.Extra.Entities;

namespace Isu.Extra.Exception;

public class ExtraGroupException : IsuExtraException
{
    private ExtraGroupException(string message) { }

    public static ExtraGroupException GroupHasTimeTable(ExtraGroup group, string message = "")
    {
        return new ExtraGroupException($"Group {group.Group.Name} already has time table. {message}");
    }
}