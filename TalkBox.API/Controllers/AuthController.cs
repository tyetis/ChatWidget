using TalkBox.API.Providers;
using TalkBox.Shared.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        MessagingService MessagingService { get; set; }
        ITokenProvider TokenProvider { get; set; }

        public AuthController(MessagingService messagingService, ITokenProvider tokenProvider)
        {
            MessagingService = messagingService;
            TokenProvider = tokenProvider;
        }

        [HttpPost]
        public IActionResult Post(Guid inboxId)
        {
            var user = MessagingService.CreateUser(inboxId, 1);
            var tokenString = TokenProvider.CreateToken(user.Id, inboxId);
            return Ok(new
            {
                token = tokenString
            });
        }
    }
}
