using Microsoft.AspNetCore.Http;
using PaymentsList.BusinessLogic.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PaymentsList.API.MiddleWares
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException e)
            {
                context.Response.StatusCode = (int)e.StatusCode;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Unexpected error!");
            }
        }
    }
}
