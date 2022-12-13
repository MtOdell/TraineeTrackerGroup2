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
    }
}
