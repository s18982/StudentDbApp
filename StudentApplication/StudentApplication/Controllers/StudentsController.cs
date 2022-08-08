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
        public StudentsController(IDbService dbService)
        {
            this._Service = dbService;
        }
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentApplication;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from student;",sqlConnection);
            
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();

            List<String> names = new List<string>();
            while (dr.Read())
            {
                names.Add(dr["LastName"].ToString());
            }
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
