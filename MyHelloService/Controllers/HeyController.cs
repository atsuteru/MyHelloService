using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyHelloService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeyController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                reply = "ご用件は何でしょうか？",
                actions = new List<object>()
                {
                    new
                    {
                        greeting = string.Format("{0}://{1}/Greeting/GoodMorning", Request.Scheme, Request.Host)
                    }
                }
            };
        }
    }
}