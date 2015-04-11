using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urvarta
{
    public partial class Service1 : ServiceBase
    {
        string today = string.Empty, filePath = string.Empty, directoryPath = string.Empty;
        DateTime start, end;
        StringBuilder state = new StringBuilder();


        public Service1()
        {
            InitializeComponent();
            this.CanHandleSessionChangeEvent = true;
        }

        protected override void OnStart(string[] args)
        {
            today = DateTime.Now.ToString("dd-MM-yy");
            directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Urvarta", today);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            filePath = Path.Combine(directoryPath, "data.csv");
            File.AppendAllText(filePath, "Service Started on :- " + DateTime.Now.ToShortTimeString() + Environment.NewLine);
        }

        protected override void OnStop()
        {
            File.AppendAllText(filePath, "Service Stopped on :- " + DateTime.Now.ToShortTimeString() + Environment.NewLine);
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLock:
                    start = DateTime.Now;
                    state.Append(start.ToShortTimeString());
                    break;
                case SessionChangeReason.SessionUnlock:
                    end = DateTime.Now;
                    state.Append("," + end.ToShortTimeString());
                    TimeSpan diff = end - start;
                    state.Append("," + Math.Round(diff.TotalMinutes, 2) + Environment.NewLine);
                    File.AppendAllText(filePath, state.ToString());
                    state.Clear();
                    break;
            }

            base.OnSessionChange(changeDescription);
        }

    }
}
