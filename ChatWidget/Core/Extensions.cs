using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.Core
{
    public static class Extensions
    {
        public static string GetValue(this JsonElement element, string property)
        {
            return element.GetProperty(property).GetString();
        }
    }
}
