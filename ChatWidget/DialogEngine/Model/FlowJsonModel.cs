using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Model
{
    public class FlowJsonModel
    {
        public string Id { get; set; }
        public string StartNode { get; set; }
        public List<NodeJsonModel> Nodes { get; set; }
    }
}
