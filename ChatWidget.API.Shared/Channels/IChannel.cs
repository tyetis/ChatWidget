using ChatWidget.API.Shared.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Channels
{
    public interface IChannel
    {
        bool OnMessageFromAgent(AgentMessage payload);
    }
}