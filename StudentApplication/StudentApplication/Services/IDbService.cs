using StudentApplication.Models;

namespace StudentApplication.Services
{
    public interface IDbService
    {
        public bool AddStudent(Student newStudent);
        IEnumerable<Student> GetAllStudents();
    }
}
