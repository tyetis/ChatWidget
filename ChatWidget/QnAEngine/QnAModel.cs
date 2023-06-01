using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.QnAEngine
{
    public class QnAModel
    {
        public string Intent { get; set; }
        public string[] Message { get; set; }
        public string FlowId { get; set; }
        public string NodeId { get; set; }
    }
}
