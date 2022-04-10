using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.AppSettings;

namespace ZAVOD_KZZ.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser => AppConfig.EmailUser;
        public string SendGridKey => AppConfig.EmailAPIKey;
    }
}
