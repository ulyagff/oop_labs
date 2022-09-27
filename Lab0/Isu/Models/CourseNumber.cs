using Isu.CustomException;
namespace Isu.Models;

public class CourseNumber
{
    private const int MaxCourse = 6;
    private const int MinCourse = 1;

    public CourseNumber(int numberOfCourse)
    {
        if ((numberOfCourse < MinCourse) & (numberOfCourse > MaxCourse))
            throw CourseNameException.IncorrectCourseNumber(numberOfCourse);
        NumberOfCourse = numberOfCourse;
    }

    public CourseNumber(char numberOfCourse)
    {
        int castCourseNumber = int.Parse(numberOfCourse.ToString());
        if ((castCourseNumber < MinCourse) & (castCourseNumber > MaxCourse))
            throw CourseNameException.IncorrectCourseNumber(castCourseNumber);
        NumberOfCourse = castCourseNumber;
    }

    public int NumberOfCourse { get; }
}