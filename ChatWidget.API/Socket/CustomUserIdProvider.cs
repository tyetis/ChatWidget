using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatWidget.API.Socket
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            var userId = ((ClaimsIdentity)connection.User.Identity).Claims.FirstOrDefault(n => n.Type == "UserId")?.Value;
            return userId;
        }
    }
}
