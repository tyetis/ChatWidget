using ChatWidget.Core;
using ChatWidget.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Actions
{
    public class SetSessionAction : BaseAction, IAction
    {
        public SetSessionAction(MessageContext context, JsonElement parameters): base(context, parameters) { }

        public void Run()
        {
            Context.Session.Set(Parameters.GetValue("key"), ExpressionInterpreter.EvalAndReplace(Parameters.GetValue("value"), Context));
        }
    }
}
