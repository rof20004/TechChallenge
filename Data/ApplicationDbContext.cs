using Microsoft.EntityFrameworkCore;
using TechChallenge.Models.Pedido;
using TechChallenge.Models.Produto;
using TechChallenge.Models.Usuario;

namespace TechChallenge_Fiap_Soat4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
