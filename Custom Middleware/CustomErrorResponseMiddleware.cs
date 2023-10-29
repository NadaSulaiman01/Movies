using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace Movies.Custom_Middleware
{
    public class CustomErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized || context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                context.Response.ContentType = "application/json";
                var response = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = "You are unauthorized to access this service."
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                if (error != null)
                {
                    context.Response.ContentType = "application/json";
                    var response = new ServiceResponseWithoutData
                    {
                        Success = false,
                        Message = $"An error occurred: {error.Message}"
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
            }
        }

    }



}
