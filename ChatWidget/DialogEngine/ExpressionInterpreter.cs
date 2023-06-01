using ChatWidget.Core;
using ChatWidget.Core.Message;
using DynamicExpresso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine
{
    public class ExpressionInterpreter
    {
        public static T Eval<T>(string expression, MessageContext context)
        {
            Interpreter interpreter = new Interpreter()
                .SetVariable("Session", context.Session)
                .SetVariable("Slots", context.Session.Slots)
                .SetVariable("UserMessage", context.UserMessage as UserTextMessage)
                .SetVariable("NLU", context.NLU)
                .SetVariable("Temp", context.Temp);
            try { return interpreter.Eval<T>(expression); } 
            catch(Exception ex) { return default(T); }
        }

        public static string EvalAndReplace(string expression, MessageContext context)
        {
            Regex rgx = new Regex(@"{{(.+)}}");
            var matches = rgx.Matches(expression);
            foreach (Match m in matches)
                expression = expression.Replace(m.Value, Eval<string>(m.Groups[1].Value, context));
            return expression;
        }
    }
}
