using Microsoft.EntityFrameworkCore;

namespace SWAPI.Data
{
    public class SwapiContext : DbContext
    {
        public SwapiContext(DbContextOptions<SwapiContext> options) : base(options)
        {
        }
        
        public DbSet<Film> Films { get; set; }
    }
}