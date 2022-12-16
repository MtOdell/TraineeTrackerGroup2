using NuGet.DependencyResolver;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.HttpManager
{
    public class CallManager
    {
        private readonly RestClient _client;
        public RestResponse RestResponse { get; set; }

        public CallManager()
        {
            _client = new RestClient("https://localhost:7166/");
        }

        public async Task<string?> MakeUserRequestAsync(string? resource, Method method)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            request.Method = method;
            request.Resource = resource;
            RestResponse = await _client.ExecuteAsync(request);
            return RestResponse.Content;
        }

        public async Task<string?> MakeUserRequestAsync(string? resource, string id, Method method)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            request.Method = method;
            request.Resource = resource + id;
            RestResponse = await _client.ExecuteAsync(request);
            return RestResponse.Content;
        }

        public async Task<string?> MakeUserRequestAsync(string? resource, Tracker tracker, Method method)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            request.Method = method;
            request.Resource = resource;
            request.AddBody(tracker);
            RestResponse = await _client.ExecuteAsync(request);
            return RestResponse.Content;
        }
    }
}
