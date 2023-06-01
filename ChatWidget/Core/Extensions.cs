using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.Core
{
    public static class Extensions
    {
        public static string GetString(this JsonElement element, string property)
        {
            return element.GetProperty(property).GetString();
        }

        public static string[] GetStringArray(this JsonElement element, string property)
        {
            return element.GetProperty(property).EnumerateArray().Select(n => n.GetString()).ToArray();
        }
    }
}
