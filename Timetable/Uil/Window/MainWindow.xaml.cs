using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MahApps.Metro.Controls;
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
            new ViewDocumentWindow(new ExcelHelper()).Show();
            Close();
        }

    }
}
