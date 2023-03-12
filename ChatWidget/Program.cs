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
            //chatBot.Train();
            chatBot.MessageHandler = (message) =>
            {
                Console.Write("Bot   : ");
                if (message is TextMessage textMessage)
                    Console.WriteLine(textMessage.Text);
                else
                    Console.WriteLine(JsonSerializer.Serialize((object)message));
            };

            chatBot.Send(new UserVisitMessage { BotId = 1, UserId = 1 });
            while (true)
            {
                Console.Write("User  : ");
                chatBot.Send(new UserTextMessage
                {
                    BotId = 1,
                    UserId = 1,
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
