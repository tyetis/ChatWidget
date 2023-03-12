using ChatWidget.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents
{
    public interface IAgent
    {
        void Send(UserMessagePayload payload, Action<AgentMessagePayload> callback = null);
    }
}
