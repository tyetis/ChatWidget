using ChatWidget.API.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        ITokenProvider TokenProvider { get; set; }

        public AuthController(ITokenProvider tokenProvider)
        {
            TokenProvider = tokenProvider;
        }

        [HttpPost]
        public IActionResult Post(int botId)
        {
            if (botId != 1) return Forbid(); // check from database
            var userId = new Random().Next(1, 999); // generate from database
            var tokenString = TokenProvider.CreateToken(userId, botId);
            return Ok(new
            {
                token = tokenString
            });
        }
    }
}
