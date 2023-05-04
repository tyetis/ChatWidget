using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Channels;
using ChatWidget.API.Shared.Common;
using ChatWidget.API.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.Http
{
    public class HttpChannel: BaseChannel, IChannel
    {
        public HttpChannel(MessagingService messagingService) : base(messagingService) { }

        public Action<AgentMessage> OnMessageFromAgentHandler { get; set; }

        public void OnMessageFromUser<T>(T payload)
        {
            var _payload = payload as HttpUserMessage;
            MessagingService.OnMessageFromUser(new ChannelMessage
            {
                UserId = _payload.UserId,
                InboxId = _payload.InboxId,
                Message = Utils.GetSystemMessage(_payload.Type, _payload.Message)
            });
        }

        public void OnMessageFromAgent(AgentMessage payload)
        {
            OnMessageFromAgentHandler(payload);
        }
    }
}
