using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Urvarta.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string today = string.Empty, filePath = string.Empty, directoryPath = string.Empty;
            StringBuilder state = new StringBuilder();

            today = DateTime.Now.ToString("dd-MM-yy");
            directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Urvarta", today);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            filePath = Path.Combine(directoryPath, DateTime.Now.ToString("hh-mm-tt") + ".png");

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "nircmd.exe";
            startInfo.Arguments = "savescreenshot " + filePath;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
