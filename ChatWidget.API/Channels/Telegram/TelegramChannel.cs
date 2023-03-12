using ChatWidget.API.Agents;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.Telegram
{
    public class TelegramChannel: BaseChannel, IChannel
    {
        public TelegramChannel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public void OnMessageFromUser(TelegramUserMessage payload)
        {
            //Save message to database
            var agent = base.GetAgent("MyChatBot.MyChatBotAgent"); // from database

            var messages = agent.OnMessageFromUser(new AgentUserMessage
            {
                Type = "UserTextMessage",
                Message = payload.Text
            });
            messages.ForEach(m => OnMessageFromAgent(m));
        }

        public bool OnMessageFromAgent(AgentMessage payload)
        {
            //Save message to database
            //Send Telegram
            return true;
        }
    }
}
