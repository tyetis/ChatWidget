using ChatWidget.API.Shared.Agents;
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
                Type = botMessage.GetType().Name,
                Message = JsonSerializer.Serialize(botMessage)
            });
            ChatBot.Send(ConvertUserMessage(payload));
        }

        public void OnMessageFromAgent(AgentMessage message)
        {
            MessagingService.OnMessageFromAgent(message);
        }

        private IUserMessage ConvertUserMessage(AgentUserMessage message)
        {
            var type = Type.GetType($"ChatWidget.Core.Message.{message.Type}, ChatWidget");
            var userMessage = (IUserMessage)JsonSerializer.Deserialize(message.Message, type);
            userMessage.UserId = Guid.Parse(message.UserId);
            userMessage.BotId = Guid.Parse(message.AgentInboxId);
            return userMessage;
        }
    }
}
