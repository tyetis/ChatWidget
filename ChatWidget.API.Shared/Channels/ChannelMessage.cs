using ChatWidget.API.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Channels
{
    public class ChannelMessage
    {
        public Guid UserId { get; set; }
        public Guid InboxId { get; set; } // if exists
        public IMessage Message { get; set; }
    }
}
