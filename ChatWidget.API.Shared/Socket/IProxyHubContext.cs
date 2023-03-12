using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Socket
{
    public interface IProxyHubContext
    {
        IHubClients Clients { get; set; }
        IGroupManager Groups { get; set; }
    }
}
