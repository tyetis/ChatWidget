using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkBox.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Chat Widget API v1.0.0";
        }
    }
}
