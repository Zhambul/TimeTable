using System;

namespace Timetable.Bll.Lessons
{
    public interface ILesson
    {
        String StartTime { get; set; }
        String Name { get; set; }
        String Teacher { get; set; }
        String Classroom { get; set; }
    }
}
