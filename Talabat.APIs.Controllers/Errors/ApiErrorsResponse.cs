using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Talabat.APIs.Controllers.Errors
{
    public class ApiErrorsResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiErrorsResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request !",
                401 => "Unauthorized !",
                403 => "Forbidden !",
                404 => "Not Found !",
                500 => "Internal Server Error !",
                _ => null
            };
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
