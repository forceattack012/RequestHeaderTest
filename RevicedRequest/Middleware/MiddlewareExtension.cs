using System;
using Microsoft.AspNetCore.Builder;

namespace RevicedRequest.Middleware {
    public static class MiddlewareExtension {
        public static IApplicationBuilder UseRevicedMiddleware (this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}