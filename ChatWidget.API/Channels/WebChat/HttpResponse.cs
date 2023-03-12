using ChatWidget.API.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.WebChat
{
    public class HttpResponse
    {
        public bool Result { get; set; }
        public List<AgentMessage> AgentMessage { get; set; }
    }
}
