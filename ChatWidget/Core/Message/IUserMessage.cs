﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.Core.Message
{
    public interface IUserMessage
    {
        public int BotId { get; set; }
        public int UserId { get; set; }
    }
}
