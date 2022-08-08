using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Models
{
    public class Student
    {

        public int IdStudent { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(100, ErrorMessage = "Nie może być dłuższe niż 100 znaków")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}",ErrorMessage = "Błędna forma")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(100, ErrorMessage = "Nie może być dłuższe niż 100 znaków")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}", ErrorMessage = "Błędna forma")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        [MaxLength(100,ErrorMessage ="Nie może być dłuższe niż 100 znaków")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Index jest wymagany")]
        [MaxLength(6, ErrorMessage = "Nie może być dłuższe niż 6 znaków")]
        public string IndexNumber { get; set; }
    }
}
