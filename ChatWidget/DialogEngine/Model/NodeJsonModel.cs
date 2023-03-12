using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Model
{
    public class NodeJsonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool WaitForAnswer { get; set; }
        public List<ActionJsonModel> OnEnterActions { get; set; }
        public List<ActionJsonModel> OnReceiveActions { get; set; }
        public List<ConditionJsonModel> NextConditions { get; set; }

    }
}
