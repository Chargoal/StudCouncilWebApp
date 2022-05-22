using System.ComponentModel.DataAnnotations;

namespace StudCouncilWebApp.Models
{
    public class Event
    {
        public Event()
        {
            EventStudents = new List<EventStudent>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Назва заходу")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Дата і час початку заходу")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Поле повинно бути не порожнім")]
        [Display(Name = "Дата і час кінця заходу")]
        public DateTime EndTime { get; set; }

        public virtual ICollection<EventStudent> EventStudents { get; set; }
    }
}
