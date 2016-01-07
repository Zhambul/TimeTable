using System;

namespace Timetable.Bll.Lessons
{
    public class Lesson : ILesson, ICloneable
    {
        public string StartTime { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Classroom { get; set; }
        public object Clone()
        {
            return new Lesson()
            {
                StartTime = StartTime,
                Name = Name,
                Teacher = Teacher,
                Classroom = Classroom
            };
        }
    }
}
