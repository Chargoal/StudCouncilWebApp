using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class Department
    {
        public Department()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Назва департаменту")]
        public string DepartmentName { get; set; }
        [Display(Name = "Факультет")]
        public int FacultyId { get; set; }

        [Display(Name = "Факультет")]
        public virtual Faculty Faculty{ get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
