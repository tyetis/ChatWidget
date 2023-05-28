using ChatWidget.Core;
using ChatWidget.Core.Message;
using ChatWidget.NLU.RasaNLU;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChatWidget.NLU.NodeNLU
{
    public class RasaNLUEngine : INLUEngine
    {
        public Config Config { get; set; }

        public RasaNLUEngine(Config config)
        {
            Config = config;
        }

        public void OnMessage(MessageContext context)
        {
            if (context.UserMessage is UserTextMessage msg)
            {
                var result = Predict(msg.Text);
                context.Session.Intent = result.intent.name;
                foreach (var entity in result.entities)
                    context.Session.Slots[entity.entity] = entity.value;
            }
        }

        public void Train(List<Utterance> utterances, int botId)
        {
        }

        private RasaResponseModel Predict(string utterance)
        {
            var httpClient = new HttpClient();
            var data = JsonSerializer.Serialize(new { text = utterance });
            var response = httpClient.PostAsync("http://localhost:5005/model/parse", new StringContent(data, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<RasaResponseModel>(content);
            }
            else return new RasaResponseModel { };
        }
    }
}
