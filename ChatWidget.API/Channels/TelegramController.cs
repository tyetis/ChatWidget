using ChatWidget.API.Channels.Telegram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TelegramController : ControllerBase
    {
        TelegramChannel Channel { get; set; }

        public TelegramController(TelegramChannel channel)
        {
            Channel = channel;
        }

        [HttpPost("send")]
        public IActionResult Send(TelegramUserMessage message)
        {
            Channel.OnMessageFromUser(message);
            return Ok();
        }
    }
}
