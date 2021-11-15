using Microsoft.AspNetCore.Http;
using PaymentsList.BusinessLogic.Exceptions;
using System;
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
            catch (GroupNotFoundException e)
            {
                //TODO
            }
            catch (UserNotFoundException e)
            {
                //TODO
            }
            catch (UserIsInThisGroup e)
            {
                //TODO
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
