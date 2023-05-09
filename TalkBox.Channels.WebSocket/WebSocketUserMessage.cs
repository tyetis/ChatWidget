using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Channels.WebSocket
{
    public class WebSocketUserMessage
    {
        public Guid UserId { get; set; }
        public Guid InboxId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
