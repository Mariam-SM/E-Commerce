
using System.Net;
using Talabat.APIs.Controllers.Errors;
using Talabat.Application.Exceptions;

namespace Talabat.APIs.Middlewares
{
    // 1 - Convention - Based
    // 2 - Factory - Based
    // 3 - Delegate - Based

    public class ExceptionHandelerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandelerMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandelerMiddleware(RequestDelegate next , ILogger<ExceptionHandelerMiddleware> logger
            , IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                // Logic After Calling the Next Middleware - Executed with the Response
                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    var response = new ApiErrorsResponse((int)HttpStatusCode.NotFound, $"This Endpoint {context.Request.Path} Not Found !");
                    await context.Response.WriteAsync(response.ToString());
                }
            }

            catch (Exception ex)
            {
                #region Logging: TODO with Serial Package

                if (_environment.IsDevelopment())
                {
                    _logger.LogError(ex, ex.Message, ex.StackTrace!.ToString());
                }
                else
                {
                    // Log the exception in External Source like Database or File(Json, Text)

                    _logger.LogError("SomeThing Went Wrong");
                } 
                #endregion


                ApiErrorsResponse response;  
                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        response = new ApiErrorsResponse((int)HttpStatusCode.NotFound, ex.Message);
                        break;
                    case BadRequestException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response = new ApiErrorsResponse((int)HttpStatusCode.BadRequest, ex.Message);
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response = _environment.IsDevelopment()
                    ? new ApiExceptionErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString())
                    : new ApiExceptionErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message);
                        break;
                }

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                 await context.Response.WriteAsync(response.ToString());
            }

          
        }
    }
}
