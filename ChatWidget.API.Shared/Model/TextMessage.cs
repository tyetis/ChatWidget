using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Model
{
    public class TextMessage: IMessage
    {
        public string Text { get; set; }
    }
}
