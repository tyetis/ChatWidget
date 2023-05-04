using ChatWidget.API.Shared.Agents;
using ChatWidget.API.Shared.Channels;
using ChatWidget.API.Shared.Model;
using ChatWidget.API.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ChatWidget.API.Channels.Telegram
{
    public class TelegramChannel : BaseChannel, IChannel
    {
        public TelegramChannel(MessagingService messagingService) : base(messagingService) { }

        public void OnMessageFromUser<T>(T payload)
        {
            var _payload = payload as TelegramUserMessage;
            var inbox = MessagingService.GetInboxFromChannel(_payload.TelegramBotId.ToString(), 2); // from channel inbox id
            var recipientId = _payload.message != null ? _payload.message.from.id : _payload.callback_query.from.id;
            var user = MessagingService.GetOrCreateUserFromChannel(inbox.InboxId, 2, recipientId.ToString()); // from channel user id
            MessagingService.OnMessageFromUser(new ChannelMessage
            {
                UserId = user.Id,
                InboxId = inbox.InboxId,
                Message = new TextMessage
                {
                    Text = _payload.message.text
                }
            });
        }

        public void OnMessageFromAgent(AgentMessage payload)
        {
            //Send Telegram
            var channelUser = MessagingService.GetChannelUser(payload.UserId, 2);
            sendToTelegram(channelUser.ChannelUserId, payload.Message, "6023162484:AAFWkPLCaBwz8-e1RVdT12e4Rkq8bzWQLag");
        }

        private void sendToTelegram(string channelUserId, IMessage message, string accessToken)
        {
            ITelegramBotClient client = new TelegramBotClient(accessToken);

            var text = message.GetType().GetProperty("Text").GetValue(message).ToString();
            client.SendTextMessageAsync(channelUserId, text).Wait();
        }
    }
}