using ChatWidget.API.Agents;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.WebSocket
{
    public class WebSocketChannel: BaseChannel, IChannel
    {
        IHubContext<ChatHub> SignalRHub { get; set; }

        public WebSocketChannel(IHubContext<ChatHub> signalRHub, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            SignalRHub = signalRHub;
        }

        public void OnMessageFromUser(WebSocketUserMessage payload)
        {
            //Save message to database
            var agent = base.GetAgent("MyChatBot.MyChatBotAgent"); // from database

            var agentMessages = agent.OnMessageFromUser(new AgentUserMessage
            {
                Type = payload.Type,
                Message = payload.Message
            });
            agentMessages.ForEach(m => OnMessageFromAgent(m));
        }

        public bool OnMessageFromAgent(AgentMessage payload)
        {
            //Save message to database
            //Send SignalR
            SignalRHub.Clients.User(payload.UserId.ToString()).SendAsync("onmessage", payload);
            return true;
        }
    }
}
