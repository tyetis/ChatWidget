using TalkBox.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TalkBox.Shared.Common
{
    public class Utils
    {
        public static IMessage GetSystemMessage(string type, string message)
        {
            var _type = Type.GetType($"TalkBox.Shared.Model.{type}");
            return (IMessage)JsonSerializer.Deserialize(message, _type);
        }
    }
}
