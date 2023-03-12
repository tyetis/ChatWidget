using ChatWidget.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents
{
    public class HumanAgent : IAgent
    {
        public void Send(UserMessagePayload payload, Action<AgentMessagePayload> callback = null)
        {
            throw new NotImplementedException();
        }
    }
}
