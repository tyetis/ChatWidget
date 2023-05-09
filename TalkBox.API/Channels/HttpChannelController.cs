using TalkBox.API.Providers;
using TalkBox.Channels.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalkBox.Shared.Channels;
using TalkBox.Shared.Service;

namespace TalkBox.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HttpChannelController : ControllerBase
    {
        HttpChannel Channel { get; set; }
        ITokenProvider TokenProvider { get; set; }

        public HttpChannelController(HttpChannel channel, ITokenProvider tokenProvider)
        {
            Channel = channel;
            TokenProvider = tokenProvider;
        }

        [HttpPost("send")]
        public HttpResponse Send(HttpUserMessage message)
        {
            message.UserId = TokenProvider.UserId.Value;
            message.InboxId = TokenProvider.InboxId.Value;
            var response = new HttpResponse { Result = true };
            Channel.OnMessageFromAgentHandler = (message) => response.AgentMessage.Add(message);
            Channel.OnMessageFromUser(message);
            return response;
        }
    }
}
