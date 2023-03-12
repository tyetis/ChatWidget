using ChatWidget.API.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ChatWidget.API.Model;

namespace ChatWidget.API.Service
{
    public abstract class BaseMessagingService
    {
        IServiceProvider ServiceProvider { get; set; }

        public BaseMessagingService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IAgent GetAgent(string userAgentType)
        {
            if (userAgentType == "MyChatBotAgent")
                return ServiceProvider.GetService<MyChatBotAgent>();
            else if (userAgentType == "HumanAgent")
                return ServiceProvider.GetService<HumanAgent>();
            else return null;
        }
    }
}
