using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Timetable.Bll;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Timetable.Dbl
{
    class ExcelHelper : DbHelperBase
    {
        protected override string FileName
        {
            get { return "TimeTable.xlsx"; }
        }

        public override void Save(List<Week> weeks)
        {
            Application application;
            Workbook workbook;
            _Worksheet worksheet;

            var path = InitExcel(out application, out workbook, out worksheet);

            LoadToExcel(weeks, worksheet);

            CloseExcel(worksheet, application, workbook, path);
        }

        private string InitExcel(out Application application, out Workbook workbook, out _Worksheet worksheet)
        {
            String path = GetFilePath();
            File.Delete(path);

            application = new Application { Visible = true };

            workbook = application.Workbooks.Add();
            worksheet = (_Worksheet)workbook.ActiveSheet;
            
            worksheet.Cells[1, 1] = "День Недели";
            worksheet.Cells[1, 2] = "Предмет";
            worksheet.Cells[1, 3] = "Время";
            worksheet.Cells[1, 4] = "Аудитория";
            worksheet.Cells[1, 5] = "Преподователь";
            return path;
        }

        private void LoadToExcel(List<Week> weeks, _Worksheet worksheet)
        {
            int currentRow = 2;

            foreach (var week in weeks)
            {
                foreach (var day in week.Days)
                {
                    var currentColumn = 1;

                    worksheet.Cells[currentRow, currentColumn] = day.Date;

                    foreach (var lesson in day.ListOfLessons)
                    {
                        currentColumn = 1;
                        PutLessonData(lesson.Name, worksheet,currentRow, ref currentColumn);
                        PutLessonData(lesson.StartTime, worksheet, currentRow, ref currentColumn);
                        PutLessonData(lesson.Classroom, worksheet, currentRow, ref currentColumn);
                        PutLessonData(lesson.Teacher, worksheet, currentRow, ref currentColumn);

                        currentRow++;
                    }
                }
            }
        }

        private void PutLessonData(String data, _Worksheet worksheet,int currentRow, ref int currentColumn)
        {
            currentColumn++;
            worksheet.Cells[currentRow, currentColumn] = data;
        }
        private static void CloseExcel(_Worksheet worksheet, Application application, Workbook workbook, string path)
        {
            var range = worksheet.Range["A1", "F1"];
            range.EntireColumn.AutoFit();

            range.Font.Bold = true;

            application.Visible = false;
            application.UserControl = false;
            workbook.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            workbook.Close();
        }


        public override List<Week> Load()
        {
            MessageBox.Show("Error! Not Implemented feature");
            return null;
        }
    }
}
