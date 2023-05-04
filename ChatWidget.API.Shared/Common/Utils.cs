using ChatWidget.API.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Common
{
    public class Utils
    {
        public static IMessage GetSystemMessage(string type, string message)
        {
            var _type = Type.GetType($"ChatWidget.API.Shared.Model.{type}");
            return (IMessage)JsonSerializer.Deserialize(message, _type);
        }
    }
}
