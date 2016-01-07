using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Bll
{
    class TimeTableMemento
    {
        public Week FirstWeek;

        public Week SecondWeek;

        public TimeTableMemento(Week firstWeek, Week secondWeek)
        {
            FirstWeek = firstWeek;
            SecondWeek = secondWeek;
        }
    }
}
