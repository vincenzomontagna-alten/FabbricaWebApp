using System.Net.Http;
using FabbricaWebApp.DelegatingHandlerNamespace;

namespace FabbricaWebApp.Services
{
    public class HttpClientTest
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientTest(IHttpClientFactory h)
        {
            //var customHandler = new DelegatingHandlerTest()
            //{
            //    InnerHandler = new HttpClientHandler()
            //}; 
            //_httpClient =new HttpClient(customHandler);
            _httpClientFactory = h;
            //_httpClient = new HttpClient();
        }

        public async Task<string> CallApi()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("HttpClientTest");
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            using HttpResponseMessage response = await httpClient.GetAsync("todos/3");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
