using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Bll;

namespace Timetable.Dbl
{
    public abstract class DbHelperBase
    {
        protected abstract String FileName { get; }
        public abstract void Save(List<Week> weeks);
        public abstract List<Week> Load();
        protected String GetFilePath()
        {
            String debugPath = AppDomain.CurrentDomain.BaseDirectory;
            String projectPath = debugPath.Substring(0, debugPath.IndexOf("\\bin\\Debug",
                StringComparison.Ordinal));
            String path = projectPath + "\\" + FileName;

            return path;
        }
    }
}
