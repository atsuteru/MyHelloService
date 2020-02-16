using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyHelloService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public class RequestBody
        {
            public string Area { get; set; }
            public string Name { get; set; }
        }

        [HttpPost]
        [Produces("text/plain")]
        public string Post([FromBody] RequestBody body, [FromQuery] bool answer)
        {
            if (!answer)
            {
                return (string.IsNullOrWhiteSpace(body.Name) ? string.Empty: body.Name + "さん")
                    + "いい一日になると良いですね";
            }
            return (string.IsNullOrWhiteSpace(body.Area) ? string.Empty : body.Area + "の")
                + "今日の天気は晴れです";
        }
    }
}