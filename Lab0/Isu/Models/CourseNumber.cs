using Isu.CustomException;
namespace Isu.Models;

public class CourseNumber
{
    private const int MaxCourse = 6;
    private const int MinCourse = 1;

    public CourseNumber(int numberOfCourse)
    {
        if ((numberOfCourse < MinCourse) & (numberOfCourse > MaxCourse))
            throw StereotypeIsuException.IncorrectCourseNumber(numberOfCourse);
        NumberOfCourse = numberOfCourse;
    }

    public int NumberOfCourse { get; }
}