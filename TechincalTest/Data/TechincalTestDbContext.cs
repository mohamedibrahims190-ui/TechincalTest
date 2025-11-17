using Microsoft.EntityFrameworkCore;
using TechincalTest.Models;

namespace TechincalTest.Data
{
    public class TechincalTestDbContext : DbContext
    {
        public TechincalTestDbContext(DbContextOptions<TechincalTestDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
