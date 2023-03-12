using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Model
{
    public class MessagingResponse
    {
        public bool Result { get; set; }
        public List<AgentMessagePayload> AgentMessage { get; set; }
    }
}
