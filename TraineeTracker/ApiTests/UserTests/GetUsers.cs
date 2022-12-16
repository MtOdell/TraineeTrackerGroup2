using APITestFramework.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.UserTests
{
    internal class GetUsers
    {
        GetUsersService _service;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _service = new GetUsersService();
            await _service.MakeRequestAsync();
        }

        [Test]
        public void StatusIs200OK()
        {
            Assert.That(_service.GetStatusCode(), Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ResponseContentTypeIsJson()
        {
            Assert.That(_service.GetResponseContentType(), Is.EqualTo("application/json"));
        }
        [Test]
        public void ConnectionIsKeepAlive()
        {
            Assert.That(_service.GetHeaderValue("Connection"), Is.EqualTo("keep-alive"));
        }
    }
}
