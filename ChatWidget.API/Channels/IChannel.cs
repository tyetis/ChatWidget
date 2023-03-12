using ChatWidget.API.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels
{
    public interface IChannel
    {
        bool OnMessageFromAgent(AgentMessage payload);
    }
}
