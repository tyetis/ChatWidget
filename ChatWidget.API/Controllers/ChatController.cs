using ChatWidget.API.Model;
using ChatWidget.API.Providers;
using ChatWidget.API.Service;
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
    public class ChatController : ControllerBase
    {
        MessagingService Messaging { get; set; }

        public ChatController(MessagingService messaging)
        {
            Messaging = messaging;
        }

        [HttpPost("send")]
        public List<AgentMessagePayload> Send(UserMessagePayload message)
        {
            var response = Messaging.OnMessageFromUser(message);
            return response.AgentMessage;
        }
    }
}
