using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class Student
    {
        public Student()
        {
            EventStudents = new List<EventStudent>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Ім'я студента")]
        public string StudentName { get; set; }
        [Display(Name = "Департамент")]
        public int DepartmentId { get; set; }
        [Display(Name = "Спеціальність")]
        public int SpecialtyId { get; set; }

        [Display(Name = "Департамент")]
        public virtual Department Department { get; set; } 
        [Display(Name = "Спеціальність")]
        public virtual Specialty Specialty { get; set; } 

        public virtual ICollection<EventStudent> EventStudents { get; set; }
    }
}
