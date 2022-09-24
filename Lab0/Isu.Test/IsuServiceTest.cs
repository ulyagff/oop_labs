using Isu.CustomException;
using Isu.Entities;
using Isu.Models;
using Xunit;

namespace Isu.Test;

public class IsuService
{
    private Services.IsuService _service;

    public IsuService()
    {
        _service = new Services.IsuService();
    }

    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        GroupName groupName = new GroupName("M3105");
        Group newGroup = _service.AddGroup(groupName);
        Student newStudent = _service.AddStudent(newGroup, "Ivan Ivanov");
        Assert.Equal(newGroup, newStudent.Group);
        Assert.Contains(newStudent, newGroup.GiveStudents());
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        GroupName groupName = new GroupName("M3105");
        Group newGroup = _service.AddGroup(groupName);
        for (int i = 0; i < Group.MaxGroupSize; i++)
        {
            _service.AddStudent(newGroup, "Ivan Ivanov");
        }

        Assert.Throws<GroupException>(() => _service.AddStudent(newGroup, "Ivan Ivanov"));
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        Assert.Throws<EntitiesNameException>(() => new GroupName("MN105"));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        GroupName groupName1 = new GroupName("M3105");
        Group group1 = _service.AddGroup(groupName1);
        GroupName groupName2 = new GroupName("M3101");
        Group group2 = _service.AddGroup(groupName2);
        Student newStudent = _service.AddStudent(group1, "Ivan Ivanov");
        _service.ChangeStudentGroup(newStudent, group2);
        Assert.Equal(group2, newStudent.Group);
        Assert.DoesNotContain(newStudent, group1.GiveStudents());
        Assert.Contains(newStudent, group2.GiveStudents());
    }
}