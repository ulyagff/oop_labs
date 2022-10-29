using Isu.Extra.Exception;

namespace Isu.Extra.Models;

public class TimeTable
{
    private List<StudyClass> _studyClasses;
    private TimeTable(List<StudyClass> studyClasses)
    {
        _studyClasses = studyClasses;
    }

    public static TimeTableBuilder Builder => new TimeTableBuilder();

    public static TimeTable Empty()
    {
        return new TimeTableBuilder().Build();
    }

    public IReadOnlyCollection<StudyClass> GetTimeTable() => _studyClasses;

    public int CountStudyDays()
    {
        return _studyClasses.Count();
    }

    public bool IsIntersection(TimeTable otherTimeTable)
    {
        foreach (var studyClass in otherTimeTable._studyClasses)
        {
            if (_studyClasses
                    .Where(i => i.WeekDay == studyClass.WeekDay)
                    .FirstOrDefault(i => i.ClassTime == studyClass.ClassTime)
                != null)
                return true;
        }

        return false;
    }

    public class TimeTableBuilder
    {
        private List<StudyClass> _studyClasses;

        public TimeTableBuilder()
        {
            _studyClasses = new List<StudyClass>();
        }

        public void AddStudyClass(StudyClass studyClass)
        {
            if (_studyClasses
                .Where(i => i.WeekDay == studyClass.WeekDay)
                .FirstOrDefault(i => i.ClassTime == studyClass.ClassTime)
                != null)
                throw TimeTableException.StudyClassIsContained();
            _studyClasses.Add(studyClass);
        }

        public TimeTable Build()
        {
            return new TimeTable(_studyClasses);
        }
    }
}