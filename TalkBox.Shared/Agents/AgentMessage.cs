using TalkBox.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Shared.Agents
{
    public class AgentMessage
    {
        public Guid UserId { get; set; }
        public IMessage Message { get; set; }
    }
}
