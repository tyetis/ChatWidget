using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Model;
using ChatWidget.API.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Channels
{
    public abstract class BaseChannel
    {
        protected MessagingService MessagingService { get; set; }

        public BaseChannel(MessagingService messagingService)
        {
            MessagingService = messagingService;
        }

        public IMessage ConvertChannelMessage(string type, string message)
        {
            var aa = new TextMessage().GetType();
            var _type = Type.GetType($"ChatWidget.API.Shared.Model.{type}");
            return (IMessage)JsonSerializer.Deserialize(message, _type);
        }
    }
}
