using ChatWidget.API.Shared.Channels;
using ChatWidget.API.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Agents
{
    public abstract class BaseAgent
    {
        protected MessagingService MessagingService { get; set; }

        public BaseAgent(MessagingService messagingService)
        {
            MessagingService = messagingService;
        }
    }
}
