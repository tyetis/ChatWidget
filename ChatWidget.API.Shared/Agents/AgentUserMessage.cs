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
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
