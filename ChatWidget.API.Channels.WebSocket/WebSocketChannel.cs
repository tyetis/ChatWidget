using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Channels;
using ChatWidget.API.Shared.Service;
using ChatWidget.API.Shared.Socket;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.WebSocket
{
    public class WebSocketChannel: BaseChannel, IChannel
    {
        IProxyHubContext SignalRHub { get; set; }

        public WebSocketChannel(MessagingService messagingService, IProxyHubContext signalRHub) : base(messagingService)
        {
            SignalRHub = signalRHub;
        }

        public void OnMessageFromUser<T>(T payload)
        {
            var _payload = payload as WebSocketUserMessage;
            MessagingService.OnMessageFromUser(new ChannelMessage
            {
                UserId = _payload.UserId,
                InboxId = _payload.InboxId,
                Message = ConvertChannelMessage(_payload.Type, _payload.Message)
            });
        }

        public void OnMessageFromAgent(AgentMessage payload)
        {
            SignalRHub.Clients.User(payload.UserId.ToString()).SendAsync("onmessage", new
            {
                UserId = payload.UserId,
                Type = payload.Message.GetType().Name,
                Message = (object)payload.Message
            }); //Send SignalR
        }
    }
}
