using ChatWidget.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine
{
    public abstract class BaseAction
    {
        protected MessageContext Context { get; set; }
        protected JsonElement Parameters { get; set; }

        public BaseAction(MessageContext context, JsonElement parameters)
        {
            Context = context;
            Parameters = parameters;
        }
    }
}
