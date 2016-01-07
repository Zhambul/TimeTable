using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Bll.Lessons;

namespace Timetable.Bll.LessonFabric
{
    interface ILessonFabric
    {
        ILesson CreateLesson();
    }
}
