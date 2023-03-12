using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Agents
{
    public class AgentMessage
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
    }
}
