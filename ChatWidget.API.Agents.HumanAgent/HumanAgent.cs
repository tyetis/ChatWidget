using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents.HumanAgent
{
    public class HumanAgent : BaseAgent, IAgent
    {
        public HumanAgent(MessagingService messagingService): base(messagingService) {}

        public void OnMessageFromUser(AgentUserMessage payload)
        {
            throw new NotImplementedException();
        }

        public void OnMessageFromAgent(AgentMessage message)
        {
            MessagingService.OnMessageFromAgent(message);
        }
    }
}
