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
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerceTemp;Integrated Security=True;");
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Habilitando tabela temporária para Usuario
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios",
                t => t.IsTemporal(
                    b =>
                    {
                        b.HasPeriodStart("PeriodoInicial");
                        b.HasPeriodEnd("PeriodoFinal");
                        b.UseHistoryTable("UsuarioHistorico");
                    }
                    )
                );

            // Filtro global para trazer apenas usuários ativos
            modelBuilder.Entity<Usuario>()
                .HasQueryFilter(a => a.SituacaoCadastro == SituacaoCadastro.Ativo);

            // Conversão
            modelBuilder.Entity<Usuario>()
                .Property(a => a.SituacaoCadastro)
                .HasConversion<string>();
        }
    }
}
