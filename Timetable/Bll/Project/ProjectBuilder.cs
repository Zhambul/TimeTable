using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Dbl;

namespace Timetable.Bll.Project
{
    public class ProjectBuilder
    {
        public Project Result { get; private set; }

        public ProjectBuilder()
        {
            Result = new Project();
        }

        public void SetDbHelper(DbHelperBase dbHelper)
        {
            Result.DbHelper = dbHelper;
        }

        public void SetTimeTableCaretaker(TimeTableCaretaker tableCaretaker)
        {
            Result.TimeTableCaretaker = tableCaretaker;
        }
    }
}
