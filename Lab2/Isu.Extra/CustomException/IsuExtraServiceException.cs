using Isu.Models;
namespace Isu.Extra.Exception;

public class IsuExtraServiceException : IsuExtraException
{
    private IsuExtraServiceException(string message) { }

    public static IsuExtraServiceException MegaFacultiesAreSimilar(IsuIdentifier id, string message = "")
    {
        return new IsuExtraServiceException($"Student with Id {id} can not to have Extra Study of his Megafaculty. {message}");
    }

    public static IsuExtraServiceException ExtraStudyIsAbsent(string message = "")
    {
        return new IsuExtraServiceException($"There is no Extra Study of the Megafaculty. {message}");
    }

    public static IsuExtraServiceException ExtraStudyStreamIsAbsent(string message = "")
    {
        return new IsuExtraServiceException($"there is no Extra Study Stream without intersections or with empty places. {message}");
    }

    public static IsuExtraServiceException ExtraGroupIsMissing(GroupName groupName, string message = "")
    {
        return new IsuExtraServiceException($"there is no Extra Study Group {groupName}. {message}");
    }

    public static IsuExtraServiceException ExtraStudentIsMissing(IsuIdentifier id, string message = "")
    {
        return new IsuExtraServiceException($"there is no Extra Student {id.Id}. {message}");
    }
}