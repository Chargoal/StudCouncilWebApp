using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class EventStudent
    {
        public int Id { get; set; }
        [Display(Name = "Захід")]
        public int EventId { get; set; }
        [Display(Name = "Студент")]
        public int StudentId { get; set; }

        [Display(Name = "Захід")]
        public virtual Event Event { get; set; }
        [Display(Name = "Студент")]
        public virtual Student Student { get; set; }
    }
}
