using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core
{
    public class NLUData
    {
        public string Intent { get; set; }
        public Dictionary<string, string> Entities { get; set; } = new Dictionary<string, string>();
    }
}
