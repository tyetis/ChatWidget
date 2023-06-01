using ChatWidget.Core;
using ChatWidget.DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine
{
    public class DialogEngine : IEngine
    {
        public Config Config { get; set; }

        public DialogEngine(Config config)
        {
            Config = config;
        }

        public void OnMessage(MessageContext context)
        {
            if (context.Temp.ContainsKey("PassDialog")) return;
            ExecuteFlow(context);
        }

        private void ExecuteFlow(MessageContext context)
        {
            var isEnter = false;
            var flow = GetFlow(context.Session.ActiveFlowId, context.Bot.Id);
            var node = GetNode(context.Session.ActiveNodeId, flow);
            if (node == null) { node = flow.Nodes[0]; context.Session.ActiveNodeId = node.Id; }
            if (context.Session.PreviousNodeId != context.Session.ActiveNodeId) isEnter = true;
            context.Session.PreviousNodeId = context.Session.ActiveNodeId;

            if (isEnter)
                node.OnEnterActions.ForEach(n => RunAction(n, context));
            else
            {
                node.OnReceiveActions.ForEach(n => RunAction(n, context));
                Next(node, context);
            }
        }

        private FlowJsonModel GetFlow(string Id, Guid botId)
        {
            var file = File.ReadAllText($"{Config.DataPath}/Bot_{botId}/Flows/{Id}.json");
            return JsonSerializer.Deserialize<FlowJsonModel>(file);
        }

        private NodeJsonModel GetNode(string Id, FlowJsonModel flow)
        {
            return flow.Nodes.FirstOrDefault(n => n.Id == Id);
        }

        private void Next(NodeJsonModel node, MessageContext context)
        {
            foreach (var c in node.NextConditions)
            {
                if (ExpressionInterpreter.Eval<bool>(c.Condition, context))
                {
                    if(c.FlowId != null) context.Session.ActiveFlowId = c.FlowId;
                    if(c.NodeId != null) context.Session.ActiveNodeId = c.NodeId;
                    ExecuteFlow(context);
                    break;
                }
            }
        }

        private void RunAction(ActionJsonModel model, MessageContext context)
        {
            var type = Type.GetType($"ChatWidget.DialogEngine.Actions.{model.ActionName}");
            var action = (IAction)Activator.CreateInstance(type, context, model.Parameters);
            action.Run();
        }
    }
}
