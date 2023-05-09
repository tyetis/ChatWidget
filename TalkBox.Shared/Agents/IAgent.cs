using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Shared.Agents
{
    public interface IAgent
    {
        void OnMessageFromUser(AgentUserMessage payload);
        void OnMessageFromAgent(AgentMessage message);
    }
}
