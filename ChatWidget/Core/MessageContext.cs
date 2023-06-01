using ChatWidget.Core.Manager;
using ChatWidget.Core.Message;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core
{
    public class MessageContext
    {
        public IUserMessage UserMessage { get; set; }
        public Action<IBotMessage> Response { get; set; }
        public MessageBot Bot { get; set; }
        public MessageUser User { get; set; }
        public ISessionManager Session { get; set; }
        public NLUData NLU { get; set; }
        public Dictionary<string, string> Temp { get; set; }
    }
}
