using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Channels.Telegram
{
    public class TelegramUserMessage
    {
        public string TelegramUserId { get; set; }
        public string Text { get; set; }
    }
}
