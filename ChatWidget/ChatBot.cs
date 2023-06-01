using ChatWidget.Core;
using ChatWidget.Core.Manager;
using ChatWidget.Core.Message;
using ChatWidget.NLU;
using ChatWidget.NLU.CherubNLU;
using ChatWidget.NLU.NodeNLU;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget
{
    public class ChatBot
    {
        public Action<IBotMessage> MessageHandler;
        private IEngine DialogEngine;
        private IEngine QnAEngine;
        private INLUEngine NLUEngine;

        public ChatBot(Config config)
        {
            DialogEngine = new DialogEngine.DialogEngine(config);
            QnAEngine = new QnAEngine.QnAEngine(config);
            NLUEngine = new RasaNLUEngine(config);
        }

        public void Send(IUserMessage userMessage)
        {
            var context = CreateMessageContext(userMessage);

            NLUEngine.OnMessage(context);
            QnAEngine.OnMessage(context);
            DialogEngine.OnMessage(context);
        }

        public void Train(int botId)
        {
            var utterance = new List<Utterance>
            {
                new Utterance { Text = "i want to buy a ticket", Intent = "buyTicket" },
                new Utterance { Text = "Do you have any free reservations", Intent = "buyReservation" },
                new Utterance { Text = "I want to be examined", Intent = "examined" }
            };
            NLUEngine.Train(utterance, botId);
        }

        private MessageContext CreateMessageContext(IUserMessage message)
        {
            return new MessageContext
            {
                UserMessage = message,
                Response = MessageHandler,
                Bot = new MessageBot { Id = message.BotId },
                User = new MessageUser { Id = message.UserId, Language = "TR" },
                Session = new SessionManager(message.UserId),
                NLU = new NLUData {},
                Temp = new Dictionary<string, string>()
            };
        }
    }
}
