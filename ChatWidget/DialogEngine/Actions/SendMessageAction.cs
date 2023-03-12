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
    public class SendMessageAction : BaseAction, IAction
    {
        public SendMessageAction(MessageContext context, JsonElement parameters): base(context, parameters) { }

        public void Run()
        {
            var typeName = Parameters.GetProperty("Type");
            var type = Type.GetType($"ChatWidget.Core.Message.{typeName}");
            var json = Parameters.GetProperty("Data").GetRawText();
            Context.Response((IBotMessage)JsonSerializer.Deserialize(json, type));
        }
    }
}
