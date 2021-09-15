using Microsoft.EntityFrameworkCore;

namespace UserAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        { }

        public DbSet<User> Users {get; set;}
        public DbSet<Genre> Genres {get; set;}
    }
}