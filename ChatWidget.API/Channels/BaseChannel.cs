using ChatWidget.API.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ChatWidget.API.Channels
{
    public abstract class BaseChannel
    {
        IServiceProvider ServiceProvider { get; set; }

        public BaseChannel(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IAgent GetAgent(string userAgentType)
        {
            var type = Type.GetType($"ChatWidget.API.Agents.{userAgentType}");
            return (IAgent)ServiceProvider.GetService(type);
        }
    }
}
