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
    public class SendTextAction : BaseAction, IAction
    {
        public SendTextAction(MessageContext context, JsonElement parameters): base(context, parameters) { }

        public void Run()
        {
            Context.Response(new TextMessage
            {
                Text = ExpressionInterpreter.EvalAndReplace(Parameters.GetValue("text"), Context)
            });
        }
    }
}
