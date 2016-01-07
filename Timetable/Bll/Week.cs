using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Timetable.Bll
{
    public class Week : ICloneable
    {
        public String Name { get; set; }
        public List<Day> Days { get; set; }

        public object Clone()
        {
            return new Week()
            {
                Name = Name,
                Days = new List<Day>(Days)
            };
        }
    }
}
