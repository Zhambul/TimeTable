using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Bll.Lessons;

namespace Timetable.Bll
{
    public class Day : ICloneable
    {
        public String Date { get; set; }
        public ObservableCollection<Lesson> ListOfLessons { get; set; }
        public object Clone()
        {
            return new Day()
            {
                Date = Date,
                ListOfLessons = new ObservableCollection<Lesson>(ListOfLessons)
            };
        }
    }
}
