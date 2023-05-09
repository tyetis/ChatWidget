using TalkBox.Shared.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Channels.Http
{
    public class HttpResponse
    {
        public bool Result { get; set; }
        public List<AgentMessage> AgentMessage { get; set; }
    }
}
