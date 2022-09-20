using Isu.CustomException;
using Isu.Entities;
using Isu.Models;
using Xunit;

namespace Isu.Test;

public class IsuService
{
    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        Services.IsuService service = new Services.IsuService();
        GroupName groupName = new GroupName("M3105");
        Group newGroup = service.AddGroup(groupName);
        Student newStudent = service.AddStudent(newGroup, "Ivan Ivanov");
        Assert.Equal(newGroup, newStudent.Group);
        Assert.Contains(newStudent, newGroup.GiveStudents());
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        Services.IsuService service = new Services.IsuService();
        GroupName groupName = new GroupName("M3105");
        Group newGroup = service.AddGroup(groupName);
        for (int i = 0; i < Group.MaxGroupSize; i++)
        {
            service.AddStudent(newGroup, "Ivan Ivanov");
        }

        Assert.Throws<IsuException>(() => service.AddStudent(newGroup, "Ivan Ivanov"));
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        Services.IsuService service = new Services.IsuService();
        GroupName groupName = new GroupName("MN105");
        Assert.Throws<IsuException>(() => service.AddGroup(groupName));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        Services.IsuService service = new Services.IsuService();
        GroupName groupName1 = new GroupName("M3105");
        Group group1 = service.AddGroup(groupName1);
        GroupName groupName2 = new GroupName("M3101");
        Group group2 = service.AddGroup(groupName2);
        Student newStudent = service.AddStudent(group1, "Ivan Ivanov");
        service.ChangeStudentGroup(newStudent, group2);
        Assert.Equal(group2, newStudent.Group);
        Assert.DoesNotContain(newStudent, group1.GiveStudents());
        Assert.Contains(newStudent, group2.GiveStudents());
    }
}