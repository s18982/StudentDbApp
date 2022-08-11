using StudentApplication.Models;

namespace StudentApplication.Services
{
    public interface IDbService
    {
        public bool AddStudent(Student newStudent);
        public IEnumerable<Student> GetAllStudents();
        public bool DeleteStudent(int IdStudent);
    }
}
