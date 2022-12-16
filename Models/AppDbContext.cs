using Microsoft.EntityFrameworkCore;

namespace ExamRoman.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Calendar> Calendars { get; set; }
    }
}
