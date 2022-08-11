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
            if (_Service.AddStudent(newStudent) == false)
            {
                return BadRequest();
            }
            else
                return Ok();
        }

        [HttpGet]
        [Route("{IdStudent}")]
        public IActionResult GetSingleStudent(int IdStudent)
        {
            foreach(Student st in _Service.GetAllStudents())
            {
                if (st.IdStudent == IdStudent)                
                    return Ok(st);                
            }
            return NotFound();
        }
        

        [HttpDelete]
        [Route("{IdStudent}")]
        public IActionResult DeleteStudent(int IdStudent)
        {
            if (_Service.DeleteStudent(IdStudent) == false)
                return BadRequest();
            else
                return Ok();
        }/*
        [HttpPut]
        public IActionResult UpdateStudent()
        {

        }*/
    }
}
