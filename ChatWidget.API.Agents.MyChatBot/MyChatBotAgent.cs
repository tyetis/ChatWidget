using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Model;
using ChatWidget.API.Shared.Service;
using ChatWidget.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents.MyChatBot
{
    public class MyChatBotAgent : BaseAgent, IAgent
    {
        ChatBot ChatBot { get; set; }

        public MyChatBotAgent(ChatBot chatBot, MessagingService messagingService): base(messagingService)
        {
            ChatBot = chatBot;
        }

        public void OnMessageFromUser(AgentUserMessage payload)
        {
            ChatBot.MessageHandler = (botMessage) => OnMessageFromAgent(new AgentMessage
            {
                UserId = Guid.Parse(payload.UserId),
                Message = ConvertAgentMessage(botMessage)
            });
            ChatBot.Send(ConvertUserMessage(payload));
        }

        public void OnMessageFromAgent(AgentMessage message)
        {
            MessagingService.OnMessageFromAgent(message);
        }

        private IUserMessage ConvertUserMessage(AgentUserMessage message)
        {
            IUserMessage userMessage = null;
            if (message.Message is Shared.Model.TextMessage msg) userMessage = new UserTextMessage
            {
                Text = msg.Text
            };
            userMessage.UserId = Guid.Parse(message.UserId);
            userMessage.BotId = Guid.Parse(message.AgentInboxId);
            return userMessage;
        }

        private IMessage ConvertAgentMessage(IBotMessage botMessage)
        {
            if (botMessage is Core.Message.TextMessage message)
                return new Shared.Model.TextMessage
                {
                    Text = message.Text
                };
            else return null;
        }
    }
}
