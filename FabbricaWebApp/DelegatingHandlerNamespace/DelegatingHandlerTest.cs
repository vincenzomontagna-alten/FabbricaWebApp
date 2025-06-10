using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace FabbricaWebApp.DelegatingHandlerNamespace
{
    public class DelegatingHandlerTest : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            Console.WriteLine("DelegatingHanlder: Before HTTP request");

            var result = await base.SendAsync(request, cancellationToken);

            result.EnsureSuccessStatusCode();

            Console.WriteLine("DelegatingHanlder: After HTTP request");

            return result;
        }
    }
}
