using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Errors;

namespace Talabat.APIs.Controllers.Controllers.Common
{
    [ApiController]
    [Route("Errors/{Code}")]
    [ApiExplorerSettings(IgnoreApi = false)]
    internal class Errors : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int Code)
        {
            //return new ObjectResult(new { StatusCode = code });
            ApiErrorsResponse response;
            switch (Code)
            {
                case (int)HttpStatusCode.NotFound:
                    response = new ApiErrorsResponse((int)HttpStatusCode.NotFound,$"The requested endPoint {Request.Path} not found!");
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    response = new ApiErrorsResponse(Code);
                    break;
                case (int)HttpStatusCode.Forbidden:
                    response = new ApiErrorsResponse(Code);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    response = new ApiErrorsResponse(Code);
                    break;
                case (int)HttpStatusCode.InternalServerError:
                    response = new ApiErrorsResponse(Code);
                    break;

            }
            return StatusCode(Code);
        }
    }
}
