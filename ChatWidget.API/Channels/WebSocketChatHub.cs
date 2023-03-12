using ChatWidget.API.Channels.WebSocket;
using ChatWidget.API.Providers;
using ChatWidget.API.Shared.Socket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Controllers
{
    [Authorize]
    public class WebSocketChatHub : Hub
    {
        ITokenProvider TokenProvider { get; set; }
        WebSocketChannel Messaging { get; set; }

        public WebSocketChatHub(WebSocketChannel messaging, ITokenProvider tokenProvider)
        {
            Messaging = messaging;
            TokenProvider = tokenProvider;
        }
        public void OnMessage(WebSocketUserMessage payload)
        {
            payload.UserId = TokenProvider.UserId.Value;
            payload.BotId = TokenProvider.BotId;
            Messaging.OnMessageFromUser(payload);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
