using System;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpHead]
        public void Action1()
        {
            Console.WriteLine("Action1");
        }
    }
}
