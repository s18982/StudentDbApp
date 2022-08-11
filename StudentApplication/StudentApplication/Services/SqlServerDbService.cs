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
            foreach (Student student in this.GetAllStudents())
            {
                if (student.IndexNumber.Equals(newStudent.IndexNumber))
                    return false;
            }
            
            using (SqlConnection con =  new SqlConnection(configuration.GetConnectionString("DefaultDbConnections")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.CommandText="Insert into student(FirstName,Lastname,Email,IndexNumber) values(@FirstName,@LastName,@Email,@IndexNumber);";
                cmd.Parameters.AddWithValue("FirstName",newStudent.FirstName);
                cmd.Parameters.AddWithValue("LastName", newStudent.LastName);
                cmd.Parameters.AddWithValue("Email", newStudent.Email);
                cmd.Parameters.AddWithValue("IndexNumber", newStudent.IndexNumber);

                con.Open();
                cmd.ExecuteReader();
                con.Dispose();
            }
            
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
        public bool DeleteStudent(int IdStudent)
        {
            bool exist = false;
            foreach (Student s in GetAllStudents())
            {
                if (s.IdStudent == IdStudent)
                    exist = true;
            }
            if (exist == false)
                return false;
            
            using(SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultDbConnections")))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Clear();

                command.CommandText = "Delete from Student where IdStudent=@IdStudent;";
                command.Parameters.AddWithValue("IdStudent",IdStudent);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Dispose();

                return true;
            }
        }

    }
}
