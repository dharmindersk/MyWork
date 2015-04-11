using System.IO;
using System.Text;

namespace TFSLockStatus
{
    public class FileLogger
    {
        public StringBuilder Log { get; set; }

        public FileLogger()
        {
            Log = new StringBuilder();
        }

        public void AppendLog(string logText)
        {
            Log.AppendLine(logText);
        }

        public void WriteLog(string logLocation, string logText = "")
        {
            var log = string.IsNullOrEmpty(logText) ? Log.ToString() : logText;
            File.WriteAllText(logLocation, log);
        }

        public void ClearLog()
        {
            Log = new StringBuilder();
        }
    }
}
