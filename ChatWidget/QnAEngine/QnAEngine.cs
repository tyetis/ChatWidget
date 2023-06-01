using ChatWidget.Core;
using ChatWidget.Core.Message;
using ChatWidget.DialogEngine;
using ChatWidget.NLU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.QnAEngine
{
    partial class QnAEngine : IEngine
    {
        public Config Config { get; set; }
        private Random Rnd = new Random();

        public QnAEngine(Config config)
        {
            Config = config;
        }

        public void OnMessage(MessageContext context)
        {
            var response = GetResponse(context.NLU.Intent, context.User.Language, context.Bot.Id);
            if (response != null)
            {
                var message = response.Message.OrderBy(n => Rnd.Next()).FirstOrDefault();
                context.Response(new TextMessage { Text = ExpressionInterpreter.EvalAndReplace(message, context) });
                if (response.FlowId != null) context.Session.ActiveFlowId = response.FlowId;
                if (response.NodeId != null) context.Session.ActiveNodeId = response.NodeId;
                if(response.FlowId == null && response.NodeId == null) context.Temp["PassDialog"] = "true";
            }
        }

        private QnAModel GetResponse(string intent, string lang, Guid botId)
        {
            var file = File.ReadAllText($"{Config.DataPath}/Bot_{botId}/QnA/Data_{lang}.json");
            var qna = JsonSerializer.Deserialize<List<QnAModel>>(file);
            return qna.FirstOrDefault(n => n.Intent == intent);
        }
    }
}
