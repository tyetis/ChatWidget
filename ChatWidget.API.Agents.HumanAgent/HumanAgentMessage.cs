using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents.HumanAgent
{
    public class HumanAgentMessage
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
    }
}
