using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
		const string WELCOME_MESSAGE = "Todo Rest API v0.0.1";

		// GET api/values
		[HttpGet]
        public string Get()
        {
            return WELCOME_MESSAGE;
        }
    }
}
