using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.WebSocket
{
    public class WebSocketUserMessage
    {
        public int UserId { get; set; }
        public int? BotId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
