using Microsoft.EntityFrameworkCore;
using eCommerce.Console.Extra.Models;

namespace eCommerce.Console.Query
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;");
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Filtro global para trazer apenas usuários ativos
            modelBuilder.Entity<Usuario>()
                .HasQueryFilter(a => a.SituacaoCadastro == "A");

        }
    }
}
