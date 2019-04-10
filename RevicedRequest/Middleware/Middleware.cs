using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RevicedRequest.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            string org = httpContext.Request.Headers["REQUEST_ORG"];
            string sig = httpContext.Request.Headers["REQUEST_SIG"];
            Console.WriteLine($"ORG : {org}\n");
            Console.WriteLine($"SIG : {sig}\n");
            if(String.IsNullOrEmpty(org) || String.IsNullOrEmpty(sig))
            {
              httpContext.Response.StatusCode = 403;
              return;
            }
            await _next(httpContext);
        }
    }
}