using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
