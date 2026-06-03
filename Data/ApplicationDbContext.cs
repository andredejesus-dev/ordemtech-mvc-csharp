using Microsoft.EntityFrameworkCore;
using OrdemTech.Models;

namespace OrdemTech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdensServicos { get; set; }
    }
}