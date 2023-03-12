using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Providers
{
    public interface ITokenProvider
    {
        string CreateToken(int userId, int botId);
        int? UserId { get; }
        int? BotId { get; }
    }
}
