//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.TeamFoundation.Client;
//using Microsoft.TeamFoundation.VersionControl.Client;
//using Microsoft.TeamFoundation.Framework.Client;
//using System.Windows.Forms;
//using Microsoft.TeamFoundation.Proxy;
//using System.Net;
//using Microsoft.TeamFoundation.Server;
//using Microsoft.TeamFoundation;
//using Microsoft.TeamFoundation.WorkItemTracking.Client;
//using System.Diagnostics;
//using System.Configuration;

//namespace Prativedan
//{
//    public class TfsRepository
//    {
//        private static string tfsName = ConfigurationManager.AppSettings["TfsServer"];

//        public static TfsTeamProjectCollection GetProjectDetailsByName(string projectName)
//        {
//            string tfsName = ConfigurationManager.AppSettings["TfsServer"];
//            TfsConfigurationServer configurationServer = new TfsConfigurationServer(new Uri(tfsName), CredentialCache.DefaultCredentials);
//            configurationServer.EnsureAuthenticated();
//            // Use the InstanceId property to get the team project collection
//            Guid tpcId = new Guid(ConfigurationManager.AppSettings["AppDev"]);
//            return configurationServer.GetTeamProjectCollection(tpcId);
//        }
//    }
//}
