using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MahApps.Metro.Controls;
using Timetable.Annotations;
using Timetable.Bll;
using Timetable.Bll.Lessons;

namespace Timetable.Uil.Window
{
    /// <summary>
    /// Interaction logic for EditDayWindow.xaml
    /// </summary>
    public partial class EditDayWindow : MetroWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Day> _resultDays;

        public ObservableCollection<Day> ResultDays
        {
            get { return _resultDays; }
            set
            {
                _resultDays = value; 
                OnPropertyChanged();
            }
        }

        public EditDayWindow(Day day)
        {
            InitializeComponent();
            DataContext = this;
            ResultDays = new ObservableCollection<Day> {day};
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ResultDays[0] = (Day) MyDataGrid.Items[0];
            DialogResult = true;
        }

        private void AddLessonButton_Click(object sender, RoutedEventArgs e)
        {
            ResultDays[0].ListOfLessons.Add(new Lesson()
            {
                Name = "Новое занятие"
            });
        }
    }
}
