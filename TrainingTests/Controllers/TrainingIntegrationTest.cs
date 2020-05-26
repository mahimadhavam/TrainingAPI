using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace TrainingTests.Controllers
{
    ///<summary>
    /// This class designed for Integration testing.
    /// Both positive and negative test cases can be added.
    /// This automated test case execution help to identify issues before deployment. 
    /// </summary>


    [TestClass]
    public class TrainingIntegrationTest
    {
        [TestMethod]
        public void TestIntegration()
        {
            var client = new HttpClient(); // no HttpServer
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:64873/api/Trainings"),
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        //Test Case to return OK if the data is available for Post Training
        [TestMethod]
        public void TestIntegrationPostData()
        {
            var client = new HttpClient();
            var payload = new Dictionary<string, string>
            {
              {"Id", "5"},
              {"TrainingName", "Test Tarining"},
              {"StartDate",  DateTime.Today.ToString()},
              {"EndDate", DateTime.Today.AddDays(2).ToString()}
            };
            string data = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(data, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:64873/api/Trainings/PostTraining"),
                Method = HttpMethod.Post,
                Content = c
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        //Test Case to return BadResult if the Training data is not available
        [TestMethod]
        public void TestIntegrationPost_WithoutPassingData()
        {
            var client = new HttpClient(); // no HttpServer
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:64873/api/Trainings"),
                Method = HttpMethod.Post
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

    }

}
