using System;
using Microsoft.EntityFrameworkCore;
using webapp_aylin.Entidades;

namespace webapp_aylin
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Orden> Orden { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Orden>().ToTable("Orden");
        }
    }
}
