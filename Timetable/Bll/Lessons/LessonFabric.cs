using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Bll.Lessons
{
    class LessonFabric
    {
        public Lesson CreateLesson(String name, String classRoom, String startTime, String teacher)
        {
            return new Lesson()
            {
                Name = name,
                Classroom = classRoom,
                StartTime = startTime,
                Teacher = teacher
            };
        }
    }
}
