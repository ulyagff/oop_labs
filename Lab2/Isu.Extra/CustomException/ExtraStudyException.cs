using Isu.Extra.Models;
using Isu.Models;
namespace Isu.Extra.Exception;

public class ExtraStudyException : IsuExtraException
{
    private ExtraStudyException(string message) { }

    public static ExtraStudyException ExtraStudyIsExist(MegaFacultyName megaFacultyName, string message = "")
    {
        return new ExtraStudyException($"Extra study of megafaculty {megaFacultyName.MegaFaculty} is already exist. {message}");
    }

    public static ExtraStudyException StreamsListIsEmpty(string message = "")
    {
        return new ExtraStudyException($"the list of study stream passed in arguments is empty. {message}");
    }

    public static ExtraStudyException MaxSizeStudyStream(string message = "")
    {
        return new ExtraStudyException($"maximum number of students on the study stream is reached, it is impossible to add a new student. {message}");
    }

    public static ExtraStudyException StudentIsMissingOnStudyStream(IsuIdentifier id, string message = "")
    {
        return new ExtraStudyException($"Student with Id {id} is missing on study stream. {message}");
    }
}