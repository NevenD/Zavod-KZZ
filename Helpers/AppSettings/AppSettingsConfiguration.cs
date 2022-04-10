using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.AppSettings
{
    public class AppSettingsConfiguration
    {
        public static IConfiguration AppSettings { get; }

        static AppSettingsConfiguration()
        {
            AppSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
