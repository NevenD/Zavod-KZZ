using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.AppSettings
{
    public static class AppConfig
    {
        #region ConnectionString    
        //getting connection string from appsettings.json
        public static string DbConnectionKey => AppSettingsConfiguration.AppSettings["ConnectionStrings:DefaultConnection"];
        public static string EmailUser => AppSettingsConfiguration.AppSettings["SendMail:SendGridUser"];
        public static string EmailAPIKey => AppSettingsConfiguration.AppSettings["SendMail:SendGridKey"];

        public static string AzureStorage => AppSettingsConfiguration.AppSettings["AzureConnectionStrings:AzureStorage"];
        public static class DGUApiKeys
        {
            // API keys
            public static string CadastreDGU => AppSettingsConfiguration.AppSettings["APIKeys:CadastreDGU"];
            public static string DigitalElevationDGU => AppSettingsConfiguration.AppSettings["APIKeys:DigitalElevationDGU"];
        }

        #endregion

    }
}
