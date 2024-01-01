using Ebtdaa.Application.Common.Dtos;
using FluentValidation;
using Newtonsoft.Json;

namespace Ebtdaa.WebApi.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                UseGlobalExceptionHandler(context, e, environment);
            }
        }

        public void UseGlobalExceptionHandler(HttpContext context, Exception ex, IWebHostEnvironment environment)
        {
            var response = context.Response;

            var result = new ExeptionResponse()
            {
                IsSuccess = false,
                Errors = new[] { "server-error" }
            };

            if (ex == null) return;
            switch (ex)
            {
                case ValidationException validationException:
                    response.StatusCode = 800;
                    result.Errors = validationException.Errors.Select(e => e.ErrorMessage).ToArray();
                    break;
                case Exception exception:
                    response.StatusCode = 800;
                    result.Errors = new[] { exception.Message };
                    break;
                default:
                    response.StatusCode = 800;
                    result.Errors = environment.IsProduction() == false ? new[] { ex.Message.ToString() }
                                                                        : null;
                    break;
            }
            response.WriteAsync(JsonConvert.SerializeObject(result));

        }
    }
}
