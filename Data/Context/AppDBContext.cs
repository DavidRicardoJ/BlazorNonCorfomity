using BlazorNonConformity.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNonConformity.Data.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Fornecedor>? Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>().ToTable("tbfornecedor");
            modelBuilder.Entity<Fornecedor>(s =>
            {
                s.HasKey(f => f.IdFornecedor);
                s.Property(f => f.IdFornecedor).HasColumnName("idFornecedor");
                s.Property(f => f.CNPJ).HasColumnName("CNPJ");
                s.Property(f => f.NomeFantasia).HasColumnName("NomeFantasia");
                s.Property(f => f.RazaoSocial).HasColumnName("RazaoSocial");
            });
        }

    }
}
