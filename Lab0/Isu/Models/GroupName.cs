using Isu.CustomException;
namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        if (groupName == null)
            throw EntitiesNameExceptionFactory.NullGroupName();
        if (groupName.Length != 5)
            throw EntitiesNameExceptionFactory.IncorrectLengthGroupName(groupName.Length);
        if (char.IsDigit(groupName[0]))
            throw EntitiesNameExceptionFactory.IncorrectSymbolGroupName(0);
        for (int i = 1; i < 5; i++)
        {
            if (!char.IsDigit(groupName[i]))
                throw EntitiesNameExceptionFactory.IncorrectSymbolGroupName(i);
        }

        Faculty = new FacultyName(groupName[0]);
        TrainingLevel = int.Parse(groupName[1].ToString());
        NumberOfCourse = new CourseNumber(int.Parse(groupName[2].ToString()));
        GroupNumber = Convert.ToInt32(groupName.Substring(3));
        GroupNameStr = groupName;
    }

    public FacultyName Faculty { get; }
    public int TrainingLevel { get; }
    public CourseNumber NumberOfCourse { get; }
    public int GroupNumber { get; }
    public string GroupNameStr { get; }
}