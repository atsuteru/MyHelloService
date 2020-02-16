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
    public class GreetingController : ControllerBase
    {
        static readonly Dictionary<string, string> GREETING_WORDS = new Dictionary<string, string>()
            {
                {"GoodMorning", "おはようございます"},
                {"GoodEvening", "こんばんは"}
            };


        [HttpGet("{greetingWord}")]
        public object Get(string greetingWord)
        {
            string message;
            if (!GREETING_WORDS.TryGetValue(greetingWord, out message))
            {
                return BadRequest();
            }
            return new
            {
                reply = string.Format("{0}。今日の天気をお調べしましょうか？", message),
                actions = new List<object>()
                {
                    new
                    {
                        action = "yes",
                        address = string.Format("{0}://{1}/Greeting/Weather?answer=true", Request.Scheme, Request.Host)
                    },
                    new
                    {
                        action = "no",
                        address = string.Format("{0}://{1}/Greeting/Weather?answer=true", Request.Scheme, Request.Host)
                    }
                }
            };
        }
    }
}