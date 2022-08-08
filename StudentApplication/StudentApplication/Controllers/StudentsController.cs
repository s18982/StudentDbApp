using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("okejo");
        }
        [HttpPost]
        public IActionResult CreateStudent(Student newStudent)
        {
            
            return Ok();
        }
    }
}
