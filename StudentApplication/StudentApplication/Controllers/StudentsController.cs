using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Services;

namespace StudentApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Wstrzykiwanie serwisu db przez konstruktor
        private readonly IDbService _Service;
        public StudentsController(IDbService dbService)
        {
            this._Service = dbService;
        }
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("okejo");
        }
        [HttpPost]
        public IActionResult CreateStudent(Student newStudent)
        {
            _Service.AddStudent(newStudent);
            
            return Ok();
        }
    }
}
