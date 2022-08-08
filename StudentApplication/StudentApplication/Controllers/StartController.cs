using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentApplication.Controllers
{
    [Route("/")]
    [ApiController]
    public class StartController : ControllerBase
    {
        [HttpGet]
        public string Start()
        {
            return "Hello! It's home page";
        }
    }
}
