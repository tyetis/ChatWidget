using ChatWidget.API.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents
{
    public abstract class BaseAgent
    {
        IServiceProvider ServiceProvider { get; set; }

        public BaseAgent(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IChannel GetChannel(string channelType)
        {
            var type = Type.GetType($"ChatWidget.API.Channels.{channelType}");
            return (IChannel)ServiceProvider.GetService(type);
        }
    }
}
