using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.Http
{
    public class HttpUserMessage
    {
        public int UserId { get; set; }
        public int? BotId { get; set; } // if exists
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
