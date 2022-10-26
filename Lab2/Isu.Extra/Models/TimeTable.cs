using Isu.Extra.Exception;

namespace Isu.Extra.Models;

public class TimeTable
{
    private TimeTable(Dictionary<Enum, Day> days)
    {
        Days = days;
    }

    public static TimeTableBuilder Builder => new TimeTableBuilder();
    public Dictionary<Enum, Day> Days { get; }

    public static TimeTable Empty()
    {
        return new TimeTableBuilder().Build();
    }

    public int CountStudyDays()
    {
        return Days.Count();
    }

    public bool IsIntersection(TimeTable otherTimeTable)
    {
        foreach (var day in Days)
        {
            if (otherTimeTable.Days.ContainsKey(day.Key))
            {
                if (day.Value.IsIntersection(otherTimeTable.Days[day.Key]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public class TimeTableBuilder
    {
        private Dictionary<Enum, Day> _days;

        public TimeTableBuilder()
        {
            _days = new Dictionary<Enum, Day>();
        }

        public void AddMonday(Day day)
        {
            if (_days.ContainsKey(Week.Monday))
                throw TimeTableException.DayIsContained(Week.Monday);
            _days.Add(Week.Monday, day);
        }

        public void AddTuesday(Day day)
        {
            if (_days.ContainsKey(Week.Tuesday))
                throw TimeTableException.DayIsContained(Week.Tuesday);
            _days.Add(Week.Tuesday, day);
        }

        public void AddWednesday(Day day)
        {
            if (_days.ContainsKey(Week.Wednesday))
                throw TimeTableException.DayIsContained(Week.Wednesday);
            _days.Add(Week.Wednesday, day);
        }

        public void AddThursday(Day day)
        {
            if (_days.ContainsKey(Week.Thursday))
                throw TimeTableException.DayIsContained(Week.Thursday);
            _days.Add(Week.Thursday, day);
        }

        public void AddFriday(Day day)
        {
            if (_days.ContainsKey(Week.Friday))
                throw TimeTableException.DayIsContained(Week.Friday);
            _days.Add(Week.Friday, day);
        }

        public void AddSaturday(Day day)
        {
            if (_days.ContainsKey(Week.Saturday))
                throw TimeTableException.DayIsContained(Week.Saturday);
            _days.Add(Week.Saturday, day);
        }

        public void AddSunday(Day day)
        {
            if (_days.ContainsKey(Week.Sunday))
                throw TimeTableException.DayIsContained(Week.Sunday);
            _days.Add(Week.Sunday, day);
        }

        public TimeTable Build()
        {
            return new TimeTable(_days);
        }
    }
}