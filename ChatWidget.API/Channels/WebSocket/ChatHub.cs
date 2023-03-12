using ChatWidget.API.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWidget.API.Channels.WebSocket;

namespace ChatWidget.API.Channels.WebSocket
{
    [Authorize]
    public class ChatHub : Hub
    {
        ITokenProvider TokenProvider { get; set; }
        WebSocketChannel Messaging { get; set; }

        public ChatHub(WebSocketChannel messaging, ITokenProvider tokenProvider)
        {
            TokenProvider = tokenProvider;
            Messaging = messaging;
        }
        public void OnMessage(WebSocketUserMessage payload)
        {
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
