using ChatWidget.API.Providers;
using ChatWidget.API.Channels.WebChat;
using ChatWidget.Core.Message;
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
    public class WebChatController : ControllerBase
    {
        WebChatChannel Channel { get; set; }
        ITokenProvider TokenProvider { get; set; }

        public WebChatController(WebChatChannel channel, ITokenProvider tokenProvider)
        {
            Channel = channel;
            TokenProvider = tokenProvider;
        }

        [HttpPost("send")]
        public HttpResponse Send(WebChatUserMessage message)
        {
            message.UserId = TokenProvider.UserId.Value;
            message.BotId = TokenProvider.BotId;
            var response = Channel.OnMessageFromUser(message);
            return response;
        }
    }
}
