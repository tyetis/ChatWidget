using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core.Message
{
    public class UserTextMessage: BaseUserMessage, IUserMessage
    {
        public string Text { get; set; }
    }
}
