using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Office
{
    public class eCommerceOfficeContext : DbContext
    {
        public DbSet<Colaborador>? Colaboradores { get; set; }
        public DbSet<Setor>? Setores { get; set; }
        public DbSet<Turma>? Turmas { get; set; }
        public DbSet<Veiculo>? Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * Não é recomendável deixar uma connection string exposta assim.
             * Porém este projeto é apenas pra fins de estudos no Entity Framework.
             * 
             */
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerceOffice;Integrated Security=True;"
            );
        }

    }
}
