using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.WebChat
{
    public class WebChatUserMessage
    {
        public int UserId { get; set; }
        public int? BotId { get; set; } // if exists
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
