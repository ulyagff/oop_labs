using Isu.CustomException;
namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        if (groupName == null)
            throw GroupNameException.NullGroupName();
        if (groupName.Length != 5)
            throw GroupNameException.IncorrectLengthGroupName(groupName.Length);
        if (char.IsDigit(groupName[0]))
            throw GroupNameException.IncorrectSymbolGroupName(0);
        for (int i = 1; i < 5; i++)
        {
            if (!char.IsDigit(groupName[i]))
                throw GroupNameException.IncorrectSymbolGroupName(i);
        }

        Faculty = new FacultyName(groupName[0]);
        TrainingLevel = int.Parse(groupName[1].ToString());
        NumberOfCourse = new CourseNumber(groupName[2]);
        GroupNumber = int.Parse(groupName.Substring(3));
        GroupNameStr = groupName;
    }

    public FacultyName Faculty { get; }
    public int TrainingLevel { get; }
    public CourseNumber NumberOfCourse { get; }
    public int GroupNumber { get; }
    public string GroupNameStr { get; }
}