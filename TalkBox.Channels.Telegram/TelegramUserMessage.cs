using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkBox.Channels.Telegram
{
    public class TelegramUserMessage
    {
        public long TelegramBotId { get; set; }
        public long update_id { get; set; }
        public TelegramMessage message { get; set; }
        public TelegramCallback callback_query { get; set; }
    }

    public class TelegramFrom
    {
        public long id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
    }

    public class TelegramChat
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
    }

    public class TelegramMessage
    {
        public long message_id { get; set; }
        public TelegramFrom from { get; set; }
        public TelegramChat chat { get; set; }
        public long date { get; set; }
        public string text { get; set; }
    }

    public class TelegramCallback
    {
        public long message_id { get; set; }
        public TelegramFrom from { get; set; }
        public TelegramMessage message { get; set; }
        public string data { get; set; }
    }
}
