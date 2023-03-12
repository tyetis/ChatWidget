using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core.Message
{
    public class TextMessage: IBotMessage
    {
        public string Text { get; set; }
    }
}
