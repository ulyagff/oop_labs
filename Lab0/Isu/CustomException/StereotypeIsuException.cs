namespace Isu.CustomException;

public static class StereotypeIsuException
{
    public static IsuException NullGroupName(string message = "")
    {
        string basicMessage = string.Format("Null string. {0}", message);
        return new IsuException(basicMessage);
    }

    public static IsuException IncorrectLengthGroupName(int value, string message = "")
    {
        string basicMessage = string.Format("Incorrect length of group name. Given length - {0}, you need - 5. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException IncorrectSymbolGroupName(int value, string message = "")
    {
        string basicMessage = string.Format("Incorrect symbol in group name. Position - {0}. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException IncorrectCourseNumber(int value, string message = "")
    {
        string basicMessage = string.Format("Course number must be between 1 and 6. In arguments - {0}. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException GroupIsContainsStudent(int value, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} already a member of this group. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException MaxSizeGroup(int value, string message = "")
    {
        string basicMessage = string.Format("Maximum group size is {0} students and it has been reached. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException MinSizeGroup(int value, string message = "")
    {
        string basicMessage = string.Format("Minimum group size is {0} students and it has been reached. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException StudentIsMissingInGroup(int value, string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} is missing in group {2}. {1}", value, message, nameOfGroup);
        return new IsuException(value, basicMessage);
    }

    public static IsuException StudentIsMissing(int value, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} is missing. {1}", value, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException FacultyIsAbsent(char facultyLetter, int value = 0, string message = "")
    {
        string basicMessage = string.Format("faculty with the letter {2} is missing in the university. {1}", message, facultyLetter);
        return new IsuException(value, basicMessage);
    }

    public static IsuException FacultyIsContainsGroup(char facultyLetter, string nameOfGroup, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The group {0} is already contained in the faculty {2}. {1}", nameOfGroup, message, facultyLetter);
        return new IsuException(value, basicMessage);
    }

    public static IsuException FacultyIsNotContainGroup(char facultyLetter, string nameOfGroup, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained in the faculty {2}. {1}", nameOfGroup, message, facultyLetter);
        return new IsuException(value, basicMessage);
    }

    public static IsuException CourseIsContainsGroup(int courseNumber, string nameOfGroup, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The group {0} is already contained in the course {2}. {1}", nameOfGroup, message, courseNumber);
        return new IsuException(value, basicMessage);
    }

    public static IsuException CourseIsNotContainGroup(int courseNumber, string nameOfGroup, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained in the course {2}. {1}", nameOfGroup, message, courseNumber);
        return new IsuException(value, basicMessage);
    }

    public static IsuException GroupIsMissing(string nameOfGroup, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained at the university. {1}", nameOfGroup, message);
        return new IsuException(value, basicMessage);
    }

    public static IsuException CourseIsMissing(int numOfCourse, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The course {0} is not contained at the university. {1}", numOfCourse, message);
        return new IsuException(value, basicMessage);
    }
}