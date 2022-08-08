using StudentApplication.Models;

namespace StudentApplication.Services
{
    public class SqlServerDbService : IDbService
    {
        public bool AddStudent(Student newStudent)
        {
            return true;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return new Student[0];
        }
    }
}
