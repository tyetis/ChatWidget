using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Channels.Http
{
    public class HttpUserMessage
    {
        public Guid UserId { get; set; }
        public Guid InboxId { get; set; } // if exists
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
