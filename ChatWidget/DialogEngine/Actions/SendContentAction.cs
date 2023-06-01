using ChatWidget.Core;
using ChatWidget.Core.Message;
using ChatWidget.DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Actions
{
    public class SendContentAction : BaseAction, IAction
    {
        public SendContentAction(MessageContext context, JsonElement parameters): base(context, parameters) { }

        public void Run()
        {
            var path = new DirectoryInfo(AppContext.BaseDirectory).Parent.Parent.Parent;
            var file = File.ReadAllText($"{path}/Data/ContentElements/{Parameters.GetString("id")}.json");
            var content = JsonSerializer.Deserialize<ContentElementJsonModel>(file);

            var type = Type.GetType($"ChatWidget.Core.Message.{content.Type}");
            var message = (IBotMessage)JsonSerializer.Deserialize(content.Data.GetRawText(), type);

            Context.Response(message);
        }
    }
}
