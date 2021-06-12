using System;
using System.Configuration;

namespace GmailBot.Utility
{
    public class AppSetting
    {
        private AppSetting()
        { }

        public static string Url { get { return ConfigurationManager.AppSettings["Url"]; } }
        public static string DriverLocation { get { return ConfigurationManager.AppSettings["DriverLocation"]; } }
    }
}
