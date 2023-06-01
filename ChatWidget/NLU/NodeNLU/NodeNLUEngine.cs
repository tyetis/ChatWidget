using ChatWidget.Core;
using ChatWidget.Core.Message;
using ChatWidget.NLU.NodeNLU;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChatWidget.NLU.NodeNLU
{
    public class NodeNLUEngine : INLUEngine
    {
        private string BatFileDir { get; set; }

        public NodeNLUEngine()
        {
            BatFileDir = @"C:\Users\TayyipYetis\Desktop\NodeNlp\run.bat";
        }

        public void OnMessage(MessageContext context)
        {
            if (context.UserMessage is UserTextMessage msg)
            {
                var result = Predict(msg.Text);
                context.NLU.Intent = result.intent;
                foreach (var entity in result.entities)
                    context.Session.Slots[entity.entity] = entity.option ?? entity.sourceText;
            }
        }

        public void Train(List<Utterance> utterances, int botId)
        {
            var output = RunNodeProcess("train");
        }

        private ResponseModel Predict(string utterance)
        {
            var output = RunNodeProcess($"predict \"{utterance}\"");
            return JsonSerializer.Deserialize<ResponseModel>(output);
        }

        private string RunNodeProcess(string command)
        {
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = BatFileDir,
                    Arguments = command,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            })
            {
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                string err = process.StandardError.ReadToEnd();
                return output;
            }

            //var proc = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = @"cmd.exe",
            //        Arguments = @"/c node C:\Users\TayyipYetis\Desktop\NodeNlp\index.js ""what is the real name of spiderman""",
            //        UseShellExecute = false,
            //        RedirectStandardOutput = true,
            //        RedirectStandardError = true,
            //    }
            //};
            //string output = proc.StandardOutput.ReadToEnd();
            //string err = proc.StandardError.ReadToEnd();
        }
    }
}
