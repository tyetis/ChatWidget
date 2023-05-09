using TalkBox.Shared.Agents;
using TalkBox.Shared.Model;
using TalkBox.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TalkBox.Shared.Channels
{
    public abstract class BaseChannel
    {
        protected MessagingService MessagingService { get; set; }

        public BaseChannel(MessagingService messagingService)
        {
            MessagingService = messagingService;
        }
    }
}
