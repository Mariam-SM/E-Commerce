using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Base;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Buggy
{
    public class BuggyController : BaseApiController
    {
        public BuggyController(IServiceManager serviceManager)
        {
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFoundRequest ()
        {
            return NotFound();  // 404
        }

        [HttpGet("server-error")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();  // 500
        }

        [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();   // 400
        }

        [HttpGet("bad-request/{id}")]  // Validation Error
        public IActionResult GetBadRequest(int id)
        {
            return Ok();  // 
        }

        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorizedRequest()
        {
            return Unauthorized();  // 401
        }

        [HttpGet("forbidden")]
        public IActionResult GetForbiddenRequest()
        {
            return Forbid();  // 403
        }

    }
}
