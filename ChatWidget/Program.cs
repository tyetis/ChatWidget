using ChatWidget.Core.Message;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace ChatWidget
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfig();
            var chatBot = new ChatBot(config);
            var BotId = Guid.Parse("44dd68c3-df95-466e-a9a3-e1d002cc0f4f");
            var UserId = Guid.NewGuid();
            //chatBot.Train();
            chatBot.MessageHandler = (message) =>
            {
                Console.Write("Bot   : ");
                if (message is TextMessage textMessage)
                    Console.WriteLine(textMessage.Text);
                else
                    Console.WriteLine(JsonSerializer.Serialize((object)message));
            };

            chatBot.Send(new UserVisitMessage { BotId = BotId, UserId = UserId });
            while (true)
            {
                Console.Write("User  : ");
                chatBot.Send(new UserTextMessage
                {
                    BotId = BotId,
                    UserId = UserId,
                    Text = Console.ReadLine()
                });
            }
        }

        private static Config GetConfig()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return new Config
            {
                DataPath = config.GetSection("DataPath").Value
            };
        }
    }
}
