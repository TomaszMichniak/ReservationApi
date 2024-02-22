using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReservationApi.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.Middleware
{
    public class ErrorHandlingMiddlawere : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddlawere> _logger;

        public ErrorHandlingMiddlawere(ILogger<ErrorHandlingMiddlawere> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundExceptions notFound) {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);
            
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
