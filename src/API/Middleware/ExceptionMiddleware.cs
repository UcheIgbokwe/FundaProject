using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using src.API.Errors;

namespace src.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: {Ex.Message}", ex.Message);
                dynamic error = ex;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                try
                {
                    context.Response.StatusCode = error.StatusCode;
                }
                catch
                {
                    var response = new ApiException(context.Response.StatusCode, ex.Message);

                    var json = JsonSerializer.Serialize(response);

                    await context.Response.WriteAsync(json);
                }
            }
        }
    }
}