using ChatWidget.API.Agents;
using ChatWidget.API.Model;
using ChatWidget.API.Socket;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Service
{
    public class MessagingService: BaseMessagingService
    {
        IHubContext<ChatHub> SignalRHub { get; set; }

        public MessagingService(IHubContext<ChatHub> signalRHub, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            SignalRHub = signalRHub;
        }

        public MessagingResponse OnMessageFromUser(UserMessagePayload payload)
        {
            //Save message to database
            var agent = base.GetAgent("MyChatBotAgent"); // from database

            var messages = new List<AgentMessagePayload>();
            agent.Send(payload, (botMessage) => messages.Add(botMessage));
            return new MessagingResponse
            {
                Result = true,
                AgentMessage = messages
            };
        }

        public void OnSignalMessageFromUser(UserMessagePayload payload)
        {
            //Save message to database
            var agent = base.GetAgent("MyChatBotAgent"); // from database

            agent.Send(payload, (agentMsg) => OnMessageFromAgent(agentMsg));
        }

        public bool OnMessageFromAgent(AgentMessagePayload payload)
        {
            //Save message to database
            //Send SignalR
            SignalRHub.Clients.User(payload.UserId.ToString()).SendAsync("onmessage", payload);
            return true;
        }
    }
}
