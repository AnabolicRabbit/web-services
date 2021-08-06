using NUnit.Framework;
using System.Net; 

namespace WebServicesTesting.Test.Base
{
    public abstract class BaseTest
    {
        public HttpWebResponse response;

        [SetUp]
        public virtual void InitializeTest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException we)
            {
                response = (HttpWebResponse)we.Response;
            }
        }
    }
}