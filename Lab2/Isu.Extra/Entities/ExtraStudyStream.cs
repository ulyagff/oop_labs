using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;

namespace Isu.Extra.Entities;

public class ExtraStudyStream
{
    private readonly int _maxStreamSize;
    private HashSet<ExtraStudent> _students;

    public ExtraStudyStream(int maxSize, MegaFaculty megaFaculty, TimeTable timeTable)
    {
        _students = new HashSet<ExtraStudent>();
        _maxStreamSize = maxSize;
        TimeTable = timeTable;
        MegaFaculty = megaFaculty;
    }

    public TimeTable TimeTable { get; }
    public MegaFaculty MegaFaculty { get; }

    public void AddStudent(ExtraStudent student)
    {
        if (IsFull())
            throw ExtraStudyException.MaxSizeStudyStream();
        _students.Add(student);
    }

    public void DeleteStudent(ExtraStudent student)
    {
        if (!_students.Contains(student))
            throw ExtraStudyException.StudentIsMissingOnStudyStream(student.Student.Id);
        _students.Remove(student);
    }

    public bool IsFull()
    {
        if (_students.Count == _maxStreamSize)
            return true;
        return false;
    }

    public IReadOnlyCollection<ExtraStudent> GetStudents() => _students;
}