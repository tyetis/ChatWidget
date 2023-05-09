using TalkBox.Shared.Channels;
using TalkBox.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Shared.Agents
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
