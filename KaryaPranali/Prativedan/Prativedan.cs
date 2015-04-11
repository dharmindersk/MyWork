using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Utility;

namespace Prativedan
{
    public partial class Prativedan : Form
    {
        private TfsTeamProjectCollection _tpc;
        private WorkItemStore _store;
        private readonly Configuration _appConfiguration;

        public Prativedan()
        {
            InitializeComponent();
            _appConfiguration = new Configuration();
            ConnectToTFS();

        }
        private void ConnectToTFS()
        {
            string tfsName = _appConfiguration["TfsServer"];
            TfsConfigurationServer configurationServer = new TfsConfigurationServer(new Uri(tfsName), CredentialCache.DefaultCredentials);
            configurationServer.EnsureAuthenticated();
            // Use the InstanceId property to get the team project collection
            Guid tpcId = new Guid(_appConfiguration["AppDev"]);
            _tpc = configurationServer.GetTeamProjectCollection(tpcId);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            _store = new WorkItemStore(_tpc);
            //iterate path upto query
            QueryHierarchy queryRoot = _store.Projects[0].QueryHierarchy;
            var pathsplits = _appConfiguration["QueryPath"].Split('/');
            QueryFolder folder = (QueryFolder)queryRoot[pathsplits[0]];
            var length = pathsplits.Length - 2;
            for (int i = 1; i <= length; i++)
            {
                folder = (QueryFolder)folder[pathsplits[i]];
            }
            QueryDefinition queryString = (QueryDefinition)folder[pathsplits.Last()];

            // Set up a dictionary to pass value of the type variable.
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("project", "AppDev");
            variables.Add("me", _store.UserDisplayName);
            variables.Add("@today", DateTime.Now.ToShortDateString());

            // Create and run the query.
            Query query = new Query(_store, queryString.QueryText, variables);
            WorkItemCollection results = query.RunQuery();

            BindingList<ReportFields> lstReportFields = new BindingList<ReportFields>();


            //foreach (WorkItem result in results)
            //{
            //    ReportFields report = new ReportFields();
            //    if (result.Fields["ID"].Value != null)
            //    report.ID = result.Fields["ID"].Value.ToString();

            //    if (result.Fields["Title"].Value != null)
            //    report.Title = result.Fields["Title"].Value.ToString();

            //    if (result.Fields["Assigned To"].Value != null)
            //    report.AssignedTo = result.Fields["Assigned To"].Value.ToString();

            //    if (result.Fields["Stack Rank"].Value != null)
            //    report.StackRank = result.Fields["Stack Rank"].Value.ToString();

            //    if (result.Fields["Priority"].Value != null)
            //    report.Priority = result.Fields["Priority"].Value.ToString();

            //    if (result.Fields["State"].Value != null)
            //    report.State = result.Fields["State"].Value.ToString();

            //    if (result.Fields["Reason"].Value != null)
            //    report.Reason = result.Fields["Reason"].Value.ToString();

            //    if (result.Fields["Original Estimate"].Value != null)
            //    report.OriginalEstimate = result.Fields["Original Estimate"].Value.ToString();

            //    if (result.Fields["Completed Work"].Value != null)
            //    report.CompletedWork = result.Fields["Completed Work"].Value.ToString();

            //    if (result.Fields["Remaining Work"].Value != null)
            //    report.RemainingWork = result.Fields["Remaining Work"].Value.ToString();

            //    if (result.Fields["Activity"].Value != null)
            //    report.Activity = result.Fields["Activity"].Value.ToString();

            //    if (result.Fields["Closed Date"].Value != null)
            //    report.ClosedDate = result.Fields["Closed Date"].Value.ToString();

            //    if (result.Fields["History"].Value != null)
            //        report.Comments = (result.Fields["History"]).Value.ToString();

            //    lstReportFields.Add(report);


            //}

            //// Serialise
            ////XmlSerializer serialiser = new XmlSerializer(typeof(List<ReportFields>));
            //XmlSerializer serialiser = new XmlSerializer(lstReportFields.GetType());
            //StreamWriter writer = new StreamWriter(@"D:\\test.xml");
            //serialiser.Serialize(writer, lstReportFields);
            //writer.Close();

            //Deserialise
            //BindingList<ReportFields> serialisedList = new BindingList<ReportFields>();
            //XmlSerializer serializer = new XmlSerializer(lstReportFields.GetType());
            //StreamReader reader = new StreamReader(@"D:\\test.xml");
            //object deserialized = serializer.Deserialize(reader.BaseStream);
            //serialisedList = (BindingList<ReportFields>)deserialized;



            foreach (WorkItem result in results)
            {
                var linkItems = result.Links;
                foreach (var item in linkItems)
                {
                    if (item is RelatedLink)
                    {
                        var rlink = (item as RelatedLink);
                        var relatedWorkItemId = rlink.RelatedWorkItemId;
                        var wi = _store.GetWorkItem(relatedWorkItemId);
                        var type = wi.Type.Name;
                        var releaseDate = string.Empty;
                        if (type.ToLower() == "bug")
                        {
                            releaseDate = wi["Release"].ToString();
                        }
                        else if (type.ToLower() == "user story")
                        {
                            releaseDate = wi["Release"].ToString();
                        }
                    }
                }
            }


            //fill grid
            //dataGridView1.DataSource = results;
            //dataGridView1.DataSource = lstReportFields;
            dataGridView1.DataSource = results;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //// Pull data from GridView and drop in Excel sheet
            //// creating Excel Application 
            //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //// creating new WorkBook within Excel application 
            //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add();
            //// creating new Excelsheet in workbook 
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //// see the excel sheet behind the program 
            //app.Visible = false;
            //// get the reference of first sheet. By default its name is Sheet1. 
            //// store its reference to worksheet 
            //worksheet = workbook.Sheets["Sheet1"];
            //worksheet = workbook.ActiveSheet;
            //// storing header part in Excel 
            //for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            //}
            //// storing Each row and column value to excel sheet 
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //    {
            //        if (dataGridView1.Rows[i].Cells[j].Value != null)
            //            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //        else
            //            worksheet.Cells[i + 2, j + 1] = "CNG";
            //    }
            //}
            //int MyCount = worksheet.UsedRange.Rows.Count;
            //Microsoft.Office.Interop.Excel.Range tempRange = worksheet.get_Range("F2:F" + MyCount);
            ////Microsoft.Office.Interop.Excel.Range tempRange2 = worksheet.get_Range("G2:G" + MyCount);
            //          // save the application 
            //workbook.Save();
            ////workbook.SaveAs("test.xlsx");
            //string p = workbook.Path;


            //// Exit from the application 
            //app.Quit();


        }
    }
}
