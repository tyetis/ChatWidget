using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Channels
{
    public class ChannelUserMessage
    {
        public Guid UserId { get; set; }
        public Guid InboxId { get; set; } // if exists
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
