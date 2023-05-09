using TalkBox.API.Controllers;
using TalkBox.Shared.Socket;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkBox.API.Utils
{
    public class ProxyHubContext: IProxyHubContext
    {
        public IHubClients Clients { get; set; }
        public IGroupManager Groups { get; set; }

        public ProxyHubContext(IHubContext<WebSocketChatHub> hubContext)
        {
            Clients = hubContext.Clients;
            Groups = hubContext.Groups;
        }
    }
}
