using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkBox.Shared.Common
{
    public class Enums
    {
        public enum MessageOwner
        {
            User = 1,
            Agent = 2
        }

        public static Dictionary<int, string> Agents = new Dictionary<int, string>
        {
            { 1, "MyChatBot.MyChatBotAgent, TalkBox.Agents.MyChatBot" },
            { 2, "HumanAgent.HumanAgent, TalkBox.Agents.HumanAgent" }
        };

        public static Dictionary<int, string> Channels = new Dictionary<int, string>
        {
            { 1, "WebSocket.WebSocketChannel, TalkBox.Channels.WebSocket" },
            { 2, "Telegram.TelegramChannel, TalkBox.Channels.Telegram" }
        };
    }
}
