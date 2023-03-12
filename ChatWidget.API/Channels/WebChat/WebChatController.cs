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

        public WebChatController(WebChatChannel channel)
        {
            Channel = channel;
        }

        [HttpPost("send")]
        public HttpResponse Send(WebChatUserMessage message)
        {
            var response = Channel.OnMessageFromUser(message);
            return response;
        }
    }
}
