using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext : DbContext
    {
 
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Explicações

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(propriedade => propriedade.RG)
                .HasColumnName("REGISTRO_GERAL")
                .HasMaxLength(10)
                .HasDefaultValue("Rg ausente")
                .IsRequired();
            modelBuilder.Entity<Usuario>().Ignore(prop => prop.Sexo); // Expressão lambda é o mais recomendável
            modelBuilder.Entity<Usuario>().Property(prop => prop.Id) // Expressão lambda é o mais recomendável
                .ValueGeneratedOnAdd();

            // Index
            modelBuilder.Entity<Usuario>().HasIndex(prop => prop.CPF); // Expressão lambda é o mais recomendável
            modelBuilder.Entity<Usuario>().HasIndex(
                    prop => new {prop.CPF, prop.Email}
                );
            modelBuilder.Entity<Usuario>().HasIndex(prop => prop.CPF) // Expressão lambda é o mais recomendável
                .IsUnique()
                .HasFilter("[CPF] is not null")
                .HasDatabaseName("IX_CPF_UNIQUE");

            // Key 
            modelBuilder.Entity<Usuario>().HasKey("Id"); // Utilizando string
            modelBuilder.Entity<Usuario>().HasKey(prop => prop.Id); // Expressão lambda é o mais recomendável
            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF"); // Exemplo de chave composta, utilizando string
            modelBuilder.Entity<Usuario>()
                .HasKey(
                    prop => new { prop.Id, prop.CPF }
                ); // Expressão lambda é o mais recomendável

            // Tabela sem chave primária
            modelBuilder.Entity<Usuario>().HasNoKey();

            modelBuilder.Entity<Usuario>().HasAlternateKey(
                "CPF"
            );

            modelBuilder.Entity<Usuario>().HasAlternateKey(
                "CPF", "Email"
            ); // Composto


            // ForeignKey
            // Relacionamento entre tabelas/Entidades:
            // Has/With + One/Many = HasOne, hasMany, WithOne, WithMany

            // One > 1 = Propriedade de navegação de objeto único
            // Many > 1 = Propriedade de navegação do tipo Lista/Coleção

            modelBuilder.Entity<Usuario>().HasOne(
                user => user.Contato
            ).WithOne(contact => contact.Usuario);


            modelBuilder.Entity<Usuario>().HasMany(
                user => user.EnderecosEntrega
                
            ).WithOne(address => address.Usuario);


            modelBuilder.Entity<Usuario>().HasMany(
                user => user.Departamentos
                
            ).WithMany(department => department.Usuarios);

            // Informando chave estrangeira
            modelBuilder.Entity<Usuario>()
            .HasOne(user => user.Contato)
            .WithOne(contact => contact.Usuario)
            .HasForeignKey<Contato>(prop => prop.UsuarioId);

            // Informando chave estrangeira
            modelBuilder.Entity<Usuario>()
            .HasMany(user => user.EnderecosEntrega)
            .WithOne(address => address.Usuario)
            .HasForeignKey(adress => adress.UsuarioId);


            // Mais métodos:

            // OnDelete
            modelBuilder.Entity<Usuario>()
            .HasOne(user => user.Contato)
            .WithOne(contact => contact.Usuario)
            .HasForeignKey<Contato>(prop => prop.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

            // IsRequired, HasMaxLength, HasPrecision

            modelBuilder.Entity<Usuario>()
                .Property(p => p.RG)
                .IsRequired()
                .HasMaxLength(12);

            //modelBuilder.Entity<Usuario>()
            //    .Property(p => p.Preco).HasPrecision(2);

            #endregion

            // Sugestão do professor:

            // Médio/Grande > +10 tabelas
            // EntityCOnfiguration para cada entidade, com a implementação do método Configure()

        }

    }
}
