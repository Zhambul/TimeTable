using System.Windows;
using MahApps.Metro.Controls;
using Timetable.Bll;
using Timetable.Bll.Project;
using Timetable.Dbl;

namespace Timetable.Uil.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var builder = new ProjectBuilder();
            builder.SetDbHelper(new ExcelHelper());
            builder.SetTimeTableCaretaker(new TimeTableCaretaker(new XmlHelper()));
            new ViewDocumentWindow(builder.Result).Show();
            Close();
        }

    }
}
