using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Dbl;

namespace Timetable.Bll
{
    public class TimeTableCaretaker
    {
        private readonly DbHelperBase _dbHelper;

        public TimeTableCaretaker(DbHelperBase dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public void SaveState(TimeTableMemento timeTable)
        {
            var weeks = new List<Week> {timeTable.FirstWeek, timeTable.SecondWeek};
            _dbHelper.Save(weeks);
        }

        public TimeTableMemento GetState()
        {
            var dbResult = _dbHelper.Load();

            return new TimeTableMemento(dbResult[0],dbResult[1]);
        }
    }
}
