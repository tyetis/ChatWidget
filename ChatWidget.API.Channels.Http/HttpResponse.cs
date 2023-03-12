using ChatWidget.API.Shared.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.Http
{
    public class HttpResponse
    {
        public bool Result { get; set; }
        public List<AgentMessage> AgentMessage { get; set; }
    }
}
