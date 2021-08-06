using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebServicesTesting.Jsons;
using WebServicesTesting.Test.Base;
using WebServicesTesting.Utilities;

namespace WebServicesTesting
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Tests : BaseTest
    {
        [Test]
        public void GetStatusCodeAfterGet()
        {
            //Act
            var actualStatusNumber = (int)response.StatusCode;
            var actualStatusDescription = response.StatusDescription;

            //Assert
            Assert.AreEqual(ExpectedResults.expectedStatusNumber, actualStatusNumber, "The actual status code differs from the expected 200.");
            Assert.AreEqual(ExpectedResults.expectedStatusDescription, actualStatusDescription, "The actual status code differs from the expected OK.");
        }

        [Test]
        public void GetContentTypeHeaderAfterGet()
        {
            //Act
            var actualContentTypeHeader = response.Headers.GetValues("content-type").FirstOrDefault();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedContentTypeHeader, actualContentTypeHeader, "The content-type header does not exist in the response.");
        }

        [Test]
        public void GetUsersNumberFromBodyAfterGet()
        {
            //Act
            string responseBody = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseBody = reader.ReadToEnd();
                }
            }

            var users = JsonConvert.DeserializeObject<List<MyArray>>(responseBody);
            int actualUsersNumber = users.Count;

            //Assert
            Assert.AreEqual(ExpectedResults.expectedUsersNumber, actualUsersNumber, "The number of users differs from 10.");
        }
    }
}