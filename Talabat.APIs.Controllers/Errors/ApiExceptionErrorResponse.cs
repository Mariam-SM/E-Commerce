using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Talabat.APIs.Controllers.Errors
{
    public class ApiExceptionErrorResponse : ApiErrorsResponse
    {
        public string? Details { get; set; }

        public ApiExceptionErrorResponse(int statusCode , string? message =null , string? details =null)
            : base(statusCode, message)
        {
            Details = details;
        }

        public override string ToString()
        {

            var serlizerOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(this, serlizerOption);
        }
    }
}
