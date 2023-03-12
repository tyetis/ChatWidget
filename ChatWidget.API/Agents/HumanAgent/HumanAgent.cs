using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents.HumanAgent
{
    public class HumanAgent : BaseAgent, IAgent
    {
        IServiceProvider ServiceProvider { get; set; }

        public HumanAgent(IServiceProvider serviceProvider): base(serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public List<AgentMessage> OnMessageFromUser(AgentUserMessage payload)
        {
            throw new NotImplementedException();
        }

        public void OnMessageFromAgent(HumanAgentMessage message)
        {
            var channel = base.GetChannel("WebSocket.WebSocketChannel"); // Get channel from database
            // Convert HumanAgentMessage to AgentMessage
            channel.OnMessageFromAgent(new AgentMessage
            {
                UserId = message.UserId,
                Type = message.Type,
                Message = message.Message
            });
        }
    }
}
