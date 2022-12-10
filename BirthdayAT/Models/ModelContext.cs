using Microsoft.EntityFrameworkCore;

namespace BirthdayAT.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }
    }
}
