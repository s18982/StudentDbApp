using StudentApplication.Models;
using System.Data.SqlClient;

namespace StudentApplication.Services
{
    public class SqlServerDbService : IDbService
    {
        private readonly IConfiguration configuration;
        
        public SqlServerDbService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool AddStudent(Student newStudent)
        {
            return true;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultDbConnections")))
            {
                SqlCommand command = new SqlCommand("select * from student;",con);
                
                con.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {   Student student = new Student();
                    
                    student.IdStudent = (int)dr["IdStudent"];
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.Email = dr["Email"].ToString();
                    student.IndexNumber = dr["IndexNumber"].ToString();

                    students.Add(student);
                }
                con.Dispose();
            }            
            return students;
        }
    }
}
