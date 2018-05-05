using System.Net;
using System.Net.Http;
using api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace tests
{
    public class AnnonceControllerTestBase
    {
        private readonly HttpClient _client;
        public AnnonceControllerTestBase()
        {
            var server = new TestServer (new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public void AnnonceGetAllTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/annonce/all");

            var response = _client.SendAsync(request).Result;
            Assert.Equal(HttpStatusCode.OK , response.StatusCode);
        }
        
    }
}