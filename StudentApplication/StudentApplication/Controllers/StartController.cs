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
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "..\\StudentApplication\\Frontend\\Home\\index.html";
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "Hello! It's home page of server.";
        }
    }
}
