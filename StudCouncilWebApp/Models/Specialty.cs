using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class Specialty
    {
        public Specialty()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Назва спеціальності")]
        public string SpecialtyName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
