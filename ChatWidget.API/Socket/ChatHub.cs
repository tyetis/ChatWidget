using ChatWidget.API.Model;
using ChatWidget.API.Providers;
using ChatWidget.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Socket
{
    [Authorize]
    public class ChatHub : Hub
    {
        ITokenProvider TokenProvider { get; set; }
        MessagingService Messaging { get; set; }

        public ChatHub(MessagingService messaging, ITokenProvider tokenProvider)
        {
            TokenProvider = tokenProvider;
            Messaging = messaging;
        }
        public void OnMessage(UserMessagePayload payload)
        {
            Messaging.OnSignalMessageFromUser(payload);
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
