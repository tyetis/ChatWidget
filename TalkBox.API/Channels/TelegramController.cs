using TalkBox.Channels.Telegram;
using TalkBox.Shared.Channels;
using TalkBox.Shared.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TalkBox.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramController : ControllerBase
    {
        IChannel Channel { get; set; }

        public TelegramController(TelegramChannel channel)
        {
            Channel = channel;
        }

        [HttpGet("Webhook")]
        public IActionResult Webhook()
        {
            ITelegramBotClient client = new TelegramBotClient("6023162484:AAFWkPLCaBwz8-e1RVdT12e4Rkq8bzWQLag");
            client.SetWebhookAsync("https://98f3-88-252-173-21.ngrok-free.app/telegram/webhook/6023162484");
            return Ok();
        }

        [HttpPost("Webhook/{telegramBotId}")]
        public IActionResult Send(long telegramBotId, [FromBody]TelegramUserMessage message)
        {
            message.TelegramBotId = telegramBotId;
            Channel.OnMessageFromUser(message);
            return Ok();
        }
    }
}
