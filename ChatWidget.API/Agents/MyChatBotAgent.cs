using ChatWidget.API.Model;
using ChatWidget.API.Providers;
using ChatWidget.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents
{
    public class MyChatBotAgent : IAgent
    {
        ChatBot ChatBot { get; set; }
        ITokenProvider TokenProvider { get; set; }

        public MyChatBotAgent(ChatBot chatBot, ITokenProvider tokenProvider)
        {
            ChatBot = chatBot;
            TokenProvider = tokenProvider;
        }

        public void Send(UserMessagePayload payload, Action<AgentMessagePayload> callback = null)
        {
            ChatBot.MessageHandler = (botMessage) => callback(new AgentMessagePayload
            {
                UserId = TokenProvider.UserId.Value,
                Type = botMessage.GetType().Name,
                Message = botMessage
            });
            ChatBot.Send(new UserTextMessage
            {
                UserId = TokenProvider.UserId.Value,
                BotId = TokenProvider.BotId.Value,
                Text = payload.Text
            });
        }
    }
}
