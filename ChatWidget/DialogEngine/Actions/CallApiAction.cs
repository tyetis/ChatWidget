using ChatWidget.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWidget.DialogEngine.Actions
{
    public class CallApiAction : BaseAction, IAction
    {
        public CallApiAction(MessageContext context, JsonElement parameters) : base(context, parameters) { }

        public void Run()
        {
            string Url = Parameters.GetValue("Url");
            string Method = base.Parameters.GetValue("Method");
            string RqParameters = base.Parameters.GetValue("Parameters");
            string ResultTempName = base.Parameters.GetValue("ResultTempName");
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(Method == "Get" ? HttpMethod.Get : HttpMethod.Post, string.Format("{0}?{1}", Url, RqParameters));
                HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();

                if (response.StatusCode != HttpStatusCode.OK)
                    return;
                Context.Temp.TryAdd(ResultTempName, response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
