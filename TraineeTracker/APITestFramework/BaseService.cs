using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APITestFramework
{
    public class BaseService
    {
        public CallManager? CallManager { get; set; }
        public JObject? ResponseJson { get; set; }
        public string? ServiceResponse { get; set; }
        public Method Method { get; set; }
        public string? Resource { get; set; }
        public HttpStatusCode GetStatusCode()
        {
            return CallManager.RestResponse.StatusCode;
        }
        public string GetHeaderValue(string name)
        {
            return CallManager.RestResponse.Headers.Where(x => x.Name == name).Select(x => x.Value.ToString()).FirstOrDefault();
        }
        public string GetResponseContentType()
        {
            return CallManager.RestResponse.ContentType;
        }
    }
}
