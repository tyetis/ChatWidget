using ChatWidget.Core.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWidget.API.Agents.HumanAgent
{
    [ApiController]
    [Route("[controller]")]
    public class HumanAgentController : ControllerBase
    {
        HumanAgent Agent { get; set; }

        public HumanAgentController(HumanAgent agent)
        {
            Agent = agent;
        }

        [HttpGet("send")]
        public IActionResult Send([FromQuery]HumanAgentMessage payload)
        {
            //payload.UserId = 1;
            //payload.Type = "TextMessage";
            //payload.Message = new TextMessage
            //{
            //    Text = "selam"
            //};
            Agent.OnMessageFromAgent(payload);
            return Ok();
        }
    }
}
