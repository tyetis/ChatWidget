using TalkBox.Shared.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Shared.Channels
{
    public interface IChannel
    {
        void OnMessageFromUser<T>(T payload);
        void OnMessageFromAgent(AgentMessage payload);
    }
}