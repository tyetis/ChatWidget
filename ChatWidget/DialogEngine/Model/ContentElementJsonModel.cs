using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Model
{
    public class ContentElementJsonModel
    {
        public string Type { get; set; }
        public JsonElement Data { get; set; }
    }
}
