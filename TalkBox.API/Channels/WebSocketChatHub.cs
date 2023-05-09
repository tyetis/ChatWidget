using TalkBox.Channels.WebSocket;
using TalkBox.API.Providers;
using TalkBox.Shared.Channels;
using TalkBox.Shared.Socket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.API.Controllers
{
    [Authorize]
    public class WebSocketChatHub : Hub
    {
        ITokenProvider TokenProvider { get; set; }
        IChannel Channel { get; set; }

        public WebSocketChatHub(WebSocketChannel channel, ITokenProvider tokenProvider)
        {
            Channel = channel;
            TokenProvider = tokenProvider;
        }
        public void OnMessage(WebSocketUserMessage payload)
        {
            payload.UserId = TokenProvider.UserId.Value;
            payload.InboxId = TokenProvider.InboxId.Value;
            Channel.OnMessageFromUser(payload);
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
