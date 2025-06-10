using System.Xml;

namespace FabbricaWebApp.Middleware
{
    public class HttpDelegatorMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpDelegatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            Console.WriteLine("Sto eseguendo una risposta http . route: " + context.Request.Path);
            Console.WriteLine("Ho ricevuto un codice di stato: " + context.Response.StatusCode);

            await _next(context);

        }
    }
}
