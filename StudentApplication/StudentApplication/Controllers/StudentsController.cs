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
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultDbConnections"));
            SqlCommand sqlCommand = new SqlCommand("select * from student;",sqlConnection);
            
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();

            List<String> names = new List<string>();
            while (dr.Read())
            {
                names.Add(dr["LastName"].ToString());
            }
            sqlConnection.Dispose();
            return Ok(names);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student newStudent)
        {
            _Service.AddStudent(newStudent);
            
            return Ok();
        }
    }
}
