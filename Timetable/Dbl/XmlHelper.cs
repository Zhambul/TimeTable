using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Timetable.Bll;
using Timetable.Bll.Lessons;

namespace Timetable.Dbl
{
    class XmlHelper : DbHelperBase
    {
        private const string Week = "Week";
        private const string Day = "Day";
        private const string Lesson = "Lesson";
        private const string TimeTable = "TimeTable";

        private const string WeekName = "WeekName";

        private const string DayName = "DayName";

        private const string LessonName = "LessonName";
        private const string LessonStartTime = "LessonStartTime";
        private const string LessonTeacher = "LessonTeacher";
        private const string LessonClassroom = "LessonClassroom";

        private LessonFabric _lessonFabric;

        public XmlHelper()
        {
            _lessonFabric = new LessonFabric();;
        }

        protected override string FileName
        {
            get { return "TimeTable.txt"; }
        }

        public override void Save(List<Week> weeks)
        {
            var timeTableXml = GetTimeTableToXml(weeks);

            timeTableXml.Save(GetFilePath());
        }
        public override List<Week> Load()
        {
            var xdoc = XDocument.Load(GetFilePath());

            var weeks = GetTimeTableFromXml(xdoc);

            return weeks;
        }
        private Lesson GetLessonFromXml(XElement lessonXml)
        {
            var name = lessonXml.Element(LessonName).Value;
            var classRoom = lessonXml.Element(LessonClassroom).Value;
            var startTime = lessonXml.Element(LessonStartTime).Value;
            var teacher = lessonXml.Element(LessonTeacher).Value;

            return _lessonFabric.CreateLesson(name, classRoom, startTime,teacher);
        }
        private Week GetWeekFromXml(XElement weekXml)
        {
            var resultWeek = new Week
            {
                Name = weekXml.Element(WeekName).Value,
                Days = new List<Day>()
            };

            foreach (var dayXml in weekXml.Elements(Day))
            {
                var resultDay = GetDayFromXml(dayXml);

                resultWeek.Days.Add(resultDay);
            }
            return resultWeek;
        }
        private Day GetDayFromXml(XElement dayXml)
        {
            var resultDay = new Day
            {
                Date = dayXml.Element(DayName).Value,
                ListOfLessons = new ObservableCollection<Lesson>()
            };

            foreach (var lessonXml in dayXml.Elements(Lesson))
            {
                var resultLesson = GetLessonFromXml(lessonXml);

                resultDay.ListOfLessons.Add(resultLesson);
            }

            return resultDay;
        }
        private List<Week> GetTimeTableFromXml(XDocument xdoc)
        {
            var resultWeeks = new List<Week>();
            var rootElement = xdoc.Element(TimeTable);

            if (rootElement != null && !rootElement.IsEmpty)
            {
                foreach (var week in rootElement.Elements(Week))
                {
                    var resultWeek = GetWeekFromXml(week);

                    resultWeeks.Add(resultWeek);
                }
            }
            return resultWeeks;

        } 
        private XElement GetTimeTableToXml(List<Week> weeks)
        {
            var timeTableXml = new XElement(TimeTable);

            foreach (var week in weeks)
            {
                var weekXml = GetWeekToXml(week);

                timeTableXml.Add(weekXml);
            }

            return timeTableXml;
        }
        private XElement GetWeekToXml(Week week)
        {
            var weekXml = new XElement(Week);

            weekXml.Add(new XElement(WeekName, week.Name));

            foreach (var day in week.Days)
            {
                var dayXml = GetDayToXml(day);

                weekXml.Add(dayXml);
            }

            return weekXml;
        }
        private XElement GetDayToXml(Day day)
        {
            var dayXml = new XElement(Day);
            dayXml.Add(new XElement(DayName, day.Date));

            foreach (var lesson in day.ListOfLessons)
            {
                var lessonXml = GetLessonToXml(lesson);

                dayXml.Add(lessonXml);
            }


            return dayXml;
        }
        private XElement GetLessonToXml(Lesson lesson)
        {
            var lessonXml = new XElement(Lesson);

            lessonXml.Add(new XElement(LessonName, lesson.Name));
            lessonXml.Add(new XElement(LessonStartTime, lesson.StartTime));
            lessonXml.Add(new XElement(LessonClassroom, lesson.Classroom));
            lessonXml.Add(new XElement(LessonTeacher, lesson.Teacher));

            return lessonXml;
        }
        
    }
}
