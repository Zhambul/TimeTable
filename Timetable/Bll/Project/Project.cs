using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Dbl;

namespace Timetable.Bll.Project
{
    public class Project
    {
        public TimeTableCaretaker TimeTableCaretaker { get; set; }

        public DbHelperBase DbHelper { get; set; }

    }
}
