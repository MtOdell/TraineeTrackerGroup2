using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib
{
    public class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string LoginUrl = ConfigurationManager.AppSettings["login_url"];
        public static readonly string RegisterUrl = ConfigurationManager.AppSettings["register_url"];
        public static readonly string ForgotPasswordUrl = ConfigurationManager.AppSettings["forgot_password_url"];

    }
}
