using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Model
{
    public class ActionJsonModel
    {
        public string ActionName { get; set; }
        public JsonElement Parameters { get; set; }
    }
}
