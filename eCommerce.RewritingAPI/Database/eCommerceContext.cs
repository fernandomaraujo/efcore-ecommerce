﻿using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eCommerce.RewritingAPI.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nome = "Mercado" },
                new Departamento { Id = 2, Nome = "Moda" },
                new Departamento { Id = 3, Nome = "Móveis" },
                new Departamento { Id = 4, Nome = "Informática" },
                new Departamento { Id = 5, Nome = "Eletrodomésticos" },
                new Departamento { Id = 6, Nome = "Eletroportáteis" },
                new Departamento { Id = 7, Nome = "Beleza" }
            );
        }

    }
}
