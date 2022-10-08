namespace Isu.CustomException;

public class GroupException : IsuException
{
    private GroupException(string message)
        : base(message) { }

    public static GroupException GroupIsContainsStudent(int id, string message = "")
    {
        return new GroupException($"Student with Id {id} already a member of this group. {message}");
    }

    public static GroupException MaxSizeGroup(int countStudent, string message = "")
    {
        return new GroupException($"Maximum group size is {countStudent} students and it has been reached. {message}");
    }

    public static GroupException MinSizeGroup(int countStudent, string message = "")
    {
        return new GroupException($"Minimum group size is {countStudent} students and it has been reached. {message}");
    }

    public static GroupException StudentIsMissingInGroup(int id, string nameOfGroup, string message = "")
    {
        return new GroupException($"Student with Id {id} is missing in group {nameOfGroup}. {message}");
    }

    public static GroupException FacultyIsContainsGroup(char facultyLetter, string nameOfGroup, string message = "")
    {
        return new GroupException($"The group {nameOfGroup} is already contained in the faculty {facultyLetter}. {message}");
    }

    public static GroupException FacultyIsNotContainGroup(char facultyLetter, string nameOfGroup, string message = "")
    {
        return new GroupException($"The group {nameOfGroup} is not contained in the faculty {facultyLetter}. {message}");
    }

    public static GroupException CourseIsContainsGroup(int courseNumber, string nameOfGroup, string message = "")
    {
        return new GroupException($"The group {nameOfGroup} is already contained in the course {courseNumber}. {message}");
    }

    public static GroupException CourseIsNotContainGroup(int courseNumber, string nameOfGroup, string message = "")
    {
        return new GroupException($"The group {nameOfGroup} is not contained in the course {courseNumber}. {message}");
    }
}