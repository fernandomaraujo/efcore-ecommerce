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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EF Core 5 >
            // Mapping: Colaborador <==> Turma
            modelBuilder.Entity<Colaborador>().HasMany(a => a.Turmas)
                .WithMany(a => a.Alunos);


            #region Mapping: Colaborador <=> Veiculo (EF Core 5+)

            // Veiculos daquele colaborador
            // Veiculos pode estar associado a mais de um colaborador
            modelBuilder.Entity<Colaborador>()
                .HasMany(v => v.Veiculos)
                .WithMany(c => c.Colaboradores)
                .UsingEntity<ColaboradorVeiculo>(
                    q => q.HasOne(a => a.Veiculo)
                        .WithMany(b => b.ColaboradoresVeiculo)
                        .HasForeignKey(c => c.VeiculoId),

                    r => r.HasOne(a => a.Colaborador)
                        .WithMany(b => b.ColaboradoresVeiculo)
                        .HasForeignKey(c => c.ColaboradorId),

                    s => s.HasKey(a => new {
                        a.ColaboradorId,
                        a.VeiculoId
                    })
                );

            #endregion

            #region Seeds
            modelBuilder.Entity<Colaborador>().HasData(
                new Colaborador() { Id = 1, Nome = "José" },
                new Colaborador() { Id = 2, Nome = "Maria" },
                new Colaborador() { Id = 3, Nome = "Luan" },
                new Colaborador() { Id = 4, Nome = "Ronaldo" },
                new Colaborador() { Id = 5, Nome = "Carlos" },
                new Colaborador() { Id = 6, Nome = "Jessica" },
                new Colaborador() { Id = 7, Nome = "Viviane" }
            );
            modelBuilder.Entity<Setor>().HasData(
                new Setor() { Id = 1, Nome = "Logistica" },
                new Setor() { Id = 2, Nome = "Separação" },
                new Setor() { Id = 3, Nome = "Financeiro" },
                new Setor() { Id = 4, Nome = "Administrativo" }
            );


            modelBuilder.Entity<Turma>().HasData(
                new Turma() { Id = 1, Nome = "Turma A1" },
                new Turma() { Id = 2, Nome = "Turma A2" },
                new Turma() { Id = 3, Nome = "Turma A3" },
                new Turma() { Id = 4, Nome = "Turma A4" },
                new Turma() { Id = 5, Nome = "Turma A5" }
            );

            modelBuilder.Entity<Veiculo>().HasData(
                new Veiculo() { Id = 1, Nome = "FIAT - Argo", Placa = "ABC-1234" },
                new Veiculo() { Id = 2, Nome = "FIAT - Mobi", Placa = "DFG-1234" },
                new Veiculo() { Id = 3, Nome = "FIAT - Sienna", Placa = "HIJ-1234" },
                new Veiculo() { Id = 4, Nome = "FIAT - Idea", Placa = "LMN-1234" },
                new Veiculo() { Id = 5, Nome = "FIAT - Toro", Placa = "OPQ-1234" }
            );

            #endregion
        }

    }
}
