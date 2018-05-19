using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Selenium.Tests
{
    public class Client
    {
        public List<API> GetAPIRequest()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts", Method.GET);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<List<API>>(response.Content);
            return result;
        }
    }
}
