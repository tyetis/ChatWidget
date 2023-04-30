using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core.Message
{
    public interface IUserMessage
    {
        public Guid BotId { get; set; }
        public Guid UserId { get; set; }
    }
}
