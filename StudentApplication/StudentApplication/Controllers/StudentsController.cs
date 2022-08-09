using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Services;
using System.Data.SqlClient;

namespace StudentApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Wstrzykiwanie serwisu db przez konstruktor
        private readonly IDbService _Service;
        private readonly IConfiguration _configuration;
        public StudentsController(IDbService dbService, IConfiguration configuration)
        {
            this._Service = dbService;
            this._configuration = configuration;
        }
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _Service.GetAllStudents();
            return Ok(students);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student newStudent)
        {
            _Service.AddStudent(newStudent);
            
            return Ok();
        }/*

        [HttpDelete]
        public IActionResult DeleteStudent(Student student)
        {

        }
        [HttpPut]
        public IActionResult UpdateStudent()
        {

        }*/
    }
}
