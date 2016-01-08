using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using Timetable.Annotations;
using Timetable.Bll;
using Timetable.Bll.Lessons;
using Timetable.Bll.Project;
using Timetable.Dbl;

namespace Timetable.Uil.Window
{
    /// <summary>
    /// Interaction logic for ViewDocumentWindow.xaml
    /// </summary>
    public partial class ViewDocumentWindow : MetroWindow, INotifyPropertyChanged
    {
        private Week _firstWeek;
        private Week _secondWeek;
        public Week FirstWeek
        {
            get { return _firstWeek; }
            set
            {
                _firstWeek = value;
                OnPropertyChanged();
            }
        }
        public Week SecondWeek
        {
            get { return _secondWeek; }
            set
            {
                _secondWeek = value;
                OnPropertyChanged();
            }
        }

        private DbHelperBase _dbHelper;

        private readonly TimeTableCaretaker _timeTableCaretaker;
  

        public ViewDocumentWindow(Project project)
        {
            _dbHelper = project.DbHelper;
            _timeTableCaretaker = project.TimeTableCaretaker;

            InitializeComponent();
            DataContext = this;
            var state = _timeTableCaretaker.GetState();
            FirstWeek = state.FirstWeek;
            SecondWeek = state.SecondWeek;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = (DataGrid) sender;
            
            var day = (Day) dataGrid.SelectedItem;
            if (day == null)
            {
                return;
            }

            var editShowWindow = new EditDayWindow(day);

            if (editShowWindow.ShowDialog() == false)
            {
                var memento = _timeTableCaretaker.GetState();
                FirstWeek = memento.FirstWeek;
                SecondWeek = memento.SecondWeek;
            }

            CheckWeek(FirstWeek);
            CheckWeek(SecondWeek);

            SaveState();
        }

        private void CheckWeek(Week week)
        {
            foreach (var day in week.Days)
            {
                for (var i = 0; i < day.ListOfLessons.Count; i++)
                {
                    var lesson = day.ListOfLessons[i];
                    if (string.IsNullOrEmpty(lesson.Name) &&
                        string.IsNullOrEmpty(lesson.Classroom) &&
                        string.IsNullOrEmpty(lesson.Teacher) &&
                        string.IsNullOrEmpty(lesson.StartTime))
                    {
                        day.ListOfLessons.Remove(lesson);
                        i--;
                    }
                }
            }
        }

        private void SaveState()
        {
            var tableMemento = new TimeTableMemento(FirstWeek, SecondWeek);
            _timeTableCaretaker.SaveState(tableMemento);
        }


        private void ExcelExportButton_Click(object sender, RoutedEventArgs e)
        {
            var weeks = new List<Week> {FirstWeek, SecondWeek};
            _dbHelper.Save(weeks);
        }
    }
}
