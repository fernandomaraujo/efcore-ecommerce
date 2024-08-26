using Microsoft.EntityFrameworkCore;

namespace eCommerce.Console.Query
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aula sobre LazyLoading:
            // Determinando uso do Proxies
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;",
                    options => options.UseQuerySplittingBehavior(
                        QuerySplittingBehavior.SplitQuery) // Definindo o comportamento sendo como o padrão
                    );

        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        // Aula sobre AutoInclude:
        // Determinando qual elemento será incluido automaticamente (Contato) quando Usuario é chamado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Navigation(a => a.Contato).AutoInclude();
        }
    }
}
