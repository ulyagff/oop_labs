namespace Isu.CustomException;

public static class GroupExceptionFactory
{
    public static GroupException GroupIsContainsStudent(int id, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} already a member of this group. {1}", id, message);
        return new GroupException(basicMessage);
    }

    public static GroupException MaxSizeGroup(int countStudent, string message = "")
    {
        string basicMessage = string.Format("Maximum group size is {0} students and it has been reached. {1}", countStudent, message);
        return new GroupException(basicMessage);
    }

    public static GroupException MinSizeGroup(int countStudent, string message = "")
    {
        string basicMessage = string.Format("Minimum group size is {0} students and it has been reached. {1}", countStudent, message);
        return new GroupException(basicMessage);
    }

    public static GroupException StudentIsMissingInGroup(int id, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} is missing in group {2}. {1}", id, message, nameOfGroup);
        return new GroupException(basicMessage);
    }

    public static GroupException FacultyIsContainsGroup(char facultyLetter, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("The group {0} is already contained in the faculty {2}. {1}", nameOfGroup, message, facultyLetter);
        return new GroupException(basicMessage);
    }

    public static GroupException FacultyIsNotContainGroup(char facultyLetter, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained in the faculty {2}. {1}", nameOfGroup, message, facultyLetter);
        return new GroupException(basicMessage);
    }

    public static GroupException CourseIsContainsGroup(int courseNumber, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("The group {0} is already contained in the course {2}. {1}", nameOfGroup, message, courseNumber);
        return new GroupException(basicMessage);
    }

    public static GroupException CourseIsNotContainGroup(int courseNumber, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained in the course {2}. {1}", nameOfGroup, message, courseNumber);
        return new GroupException(basicMessage);
    }
}