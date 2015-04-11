using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using CommandLine.Utility;
using Utility;

namespace TFSLockStatus
{
    class Program
    {
        private static TfsConfigurationServer _configurationServer;
        private static FileLogger _logger;
        private static Configuration _appConfiguration;

        static void Main(string[] args)
        {
            #region Argument Parsing

            Arguments parameters = new Arguments(args);
            string url = parameters["SERVERURL"] ?? _appConfiguration["TfsServer"];
            string codePath = parameters["CODEPATH"];
            string uName = parameters["UNAME"];
            string paswd = parameters["PASWD"];

            string smtpServer = parameters["SMTPSERVER"] ?? string.Empty;
            string recipients = parameters["NOTIFICATIONRECIPIENTS"] ?? string.Empty;
            string from = parameters["NOTIFICATIONSENDER"] ?? string.Empty;
            string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _logger = new FileLogger();
            _appConfiguration = new Configuration();

            GetLockedFiles(url, codePath, uName, paswd);
            Emailer.SendMail(smtpServer, from, recipients.Split(',').ToList(), null, "yes", _logger.Log.ToString(), null);
            if (currentDirectory != null) _logger.WriteLog(Path.Combine(currentDirectory, "LockSummary.txt"), _logger.Log.ToString());
            _logger.ClearLog();

            #endregion

        }

        private static void GetLockedFiles(string serverUrl, string serverPath, string uname, string paswd)
        {
            _logger.AppendLog("LOG: " + string.Format("{0:MMM-dd-yyyy_hh-mm-ss-tt}----", DateTime.Now));

            //TfsConfigurationServer 
            if (string.IsNullOrEmpty(uname) && string.IsNullOrEmpty(paswd))
            {
                _configurationServer = new TfsConfigurationServer(new Uri(serverUrl), CredentialCache.DefaultCredentials);
            }
            else
            {
                _configurationServer = new TfsConfigurationServer(new Uri(serverUrl), new NetworkCredential(uname, paswd, "ag"));
            }

            _configurationServer.EnsureAuthenticated();
            TfsTeamProjectCollection tpc = _configurationServer.GetTeamProjectCollection(new Guid(_appConfiguration["AppDev"]));
            var vcServer = (VersionControlServer)tpc.GetService(typeof(VersionControlServer));

            // Search for pending sets for all users in all 
            // workspaces under the passed path.
            PendingSet[] pendingSets = vcServer.QueryPendingSets(new[] { serverPath }, RecursionType.Full, null, null);

            _logger.AppendLog(string.Format("#Found {0} pending sets under {1}. Searching for Locks...", pendingSets.Length, serverPath));

            foreach (PendingSet changeset in pendingSets)
            {
                foreach (PendingChange change in changeset.PendingChanges)
                {
                    if (change.IsLock)
                    {
                        // We have a lock, display details about it.
                        _logger.AppendLog(string.Format("\t>{0} : Locked for {1} by {2} on {3}.", change.ServerItem, change.LockLevelName, changeset.OwnerName, changeset.Computer));
                    }
                }
            }

        }
    }
}
