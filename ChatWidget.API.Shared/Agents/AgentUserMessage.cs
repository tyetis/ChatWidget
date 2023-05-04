using ChatWidget.API.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Agents
{
    public class AgentUserMessage
    {
        public string UserId { get; set; }
        public string AgentInboxId { get; set; }
        public IMessage Message { get; set; }
    }
}
