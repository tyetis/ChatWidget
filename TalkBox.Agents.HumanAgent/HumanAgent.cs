using TalkBox.Shared.Agents;
using TalkBox.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Agents.HumanAgent
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
