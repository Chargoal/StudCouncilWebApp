using Microsoft.EntityFrameworkCore;

namespace StudCouncilWebApp.Models
{
    public class StudCouncilContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventStudent> EventStudents { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public StudCouncilContext(DbContextOptions<StudCouncilContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
