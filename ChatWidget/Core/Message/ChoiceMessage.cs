using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core.Message
{
    public class ChoiceMessage: IBotMessage
    {
        public List<ChoiceElementItem> Choices { get; set; }
    }

    public class ChoiceElementItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
