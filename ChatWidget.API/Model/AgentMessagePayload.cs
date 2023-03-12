using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Model
{
    public class AgentMessagePayload
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
    }
}
