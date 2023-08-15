using APIAutomation.Constants;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.Tests
{
    [TestFixture]
    public class UserClass : BaseClass
    {

        [Test,Order(1)]
        public void POSTUser()
        {
            var request = new RestRequest();
            var body = @"{
                           " + "\n" +
                                       @"""id"": 0,
                           " + "\n" +
                                       @"""username"": ""test"",
                           " + "\n" +
                                       @"""firstName"": ""test1"",
                           " + "\n" +
                                       @"""lastName"": ""last"",
                           " + "\n" +
                                       @"""email"": ""string@gmial.com"",
                           " + "\n" +
                                       @"""password"": ""string12345"",
                           " + "\n" +
                                       @"""phone"": ""07888456413"",
                           " + "\n" +
                                       @"""userStatus"": 0
                           " + "\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Post(request);
            Console.WriteLine(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(2)]
        public void GetUser()
        {

            var request = new RestRequest(Endpoints.userurl)
                .AddUrlSegment("username", UrlParameter.usernames);
            request.AddHeader("content-type", "application/json");
            var response = _client.Get(request);
            Console.WriteLine(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test, Order(3)]
        public void DeleteUser()
        {

            var request = new RestRequest(Endpoints.userurl)
                .AddUrlSegment("username", UrlParameter.usernames);
            var response = _client.Delete(request);
            Console.WriteLine(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }



    }
}
