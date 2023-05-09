using TalkBox.Agents.HumanAgent;
using TalkBox.Shared.Agents;
using TalkBox.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.API.Controllers
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
            payload.UserId = Guid.Parse("A8045EE3-A958-4F09-B45F-1676D256E6D1");
            Agent.OnMessageFromAgent(new AgentMessage
            {
                UserId = payload.UserId,
                Message = new TextMessage
                {
                    Text = "Hello"
                }
            });
            return Ok();
        }
    }
}
