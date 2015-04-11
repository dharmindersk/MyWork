using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Net;
using Utility;
using System.Text;
using System.Collections;

namespace KaryaPranali
{
    public partial class Karya : Form
    {
        private TfsTeamProjectCollection _tpc;
        private WorkItemStore _store;
        private readonly Configuration _appConfiguration;

        public Karya()
        {
            InitializeComponent();
            _appConfiguration = new Configuration();
            txtLocation.Text = @"D:\WorkItems\";
            txtLocation.Enabled = false;
        }

        private void ConnectToTFS()
        {
            lblInfo.Text = "Connecting to TFS. . .";
            string tfsName = _appConfiguration["TfsServer"];
            TfsConfigurationServer configurationServer = new TfsConfigurationServer(new Uri(tfsName), CredentialCache.DefaultCredentials);
            configurationServer.EnsureAuthenticated();
            // Use the InstanceId property to get the team project collection
            Guid tpcId = new Guid(_appConfiguration["AppDev"]);
            _tpc = configurationServer.GetTeamProjectCollection(tpcId);
            lblInfo.Text = "Connected to TFS.";
        }

        private IEnumerable<string> ParseWorkItem(string allWorkItems)
        {
            var workitems = allWorkItems.Split(new char[] { ',', ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return workitems;
        }

        private void btnProcessQueue_Click(object sender, EventArgs e)
        {
            ConnectToTFS();
            _store = new WorkItemStore(_tpc);
            var wis = ParseWorkItem(txtAllWis.Text);

            Task.Factory.StartNew(() =>
            {
                foreach (var item in wis)
                {
                    int wno;
                    int.TryParse(item, out wno);
                    if (wno == 0) continue;
                    DownloadWiDetails(wno);
                }
            }).ContinueWith((t) =>
            {
                //lblInfo.Text = "Completed";
            });
        }

        private void DownloadWiDetails(int wno)
        {
            var wi = _store.GetWorkItem(wno);
            string folderPath = Path.Combine(txtLocation.Text, wi.Id.ToString(CultureInfo.InvariantCulture) + string.Format("{0:_MMM-dd-yyyy}", DateTime.Now));
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            try
            {
                var reprosteps = wi.Fields["Repro Steps"].Value.ToString();
                if (!string.IsNullOrEmpty(reprosteps))
                {
                    File.WriteAllText(Path.Combine(folderPath, "Steps To Reproduce.html"), reprosteps);
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(folderPath, "errors.txt"), ex.ToString());
            }

            try
            {
                var description = wi.Fields["Description"].Value.ToString();
                if (!string.IsNullOrEmpty(description))
                {
                    File.WriteAllText(Path.Combine(folderPath, "Description.html"), description);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(folderPath, "errors.txt"), ex.ToString());
            }

            Stack<string> stack = new Stack<string>();

            RevisionCollection revisions = wi.Revisions;
            foreach (Revision revision in revisions)
            {
                String history = revision.Fields["History"].Value.ToString().Trim();
                if (!string.IsNullOrEmpty(history))
                {
                    stack.Push(string.Format("<p>{0}<br />#: {1}</p>", wi.Fields["Changed Date"].Value, StripTagsRegexCompiled(history)));
                }
            }
            stack.Push(string.Format("<h3>{0}</h3>", wi.Fields["Title"].Value));

            File.WriteAllText(Path.Combine(folderPath, "More Details.html"), "");
            foreach (var item in stack)
            {
                File.AppendAllText(Path.Combine(folderPath, "More Details.html"), item);
            }

            foreach (Attachment attachment in wi.Attachments)
            {
                string fileName = attachment.Name;
                string attachmentUri = attachment.Uri.ToString();

                using (var wClient = new WebClient())
                {
                    wClient.Credentials = CredentialCache.DefaultCredentials;
                    wClient.DownloadFile(attachmentUri, Path.Combine(folderPath, fileName));
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fldDialog.SelectedPath = txtLocation.Text;
            fldDialog.ShowDialog();
            txtLocation.Text = fldDialog.SelectedPath;
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

    }
}
