using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class Faculty
    {
        public Faculty()
        {
            Departments = new List<Department>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Назва факультета")]
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
