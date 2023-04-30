using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Providers
{
    public interface ITokenProvider
    {
        string CreateToken(Guid userId, Guid botId);
        Guid? UserId { get; }
        Guid? InboxId { get; }
    }
}
