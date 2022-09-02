using Microsoft.EntityFrameworkCore;
//using System.Data.

namespace TesteTecnicoWK.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categorias> Categoria { get; set; }

        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>().HasMany(r => r.Produtos);

            //Para criar os dados iniciais quando for feita a migration
            modelBuilder.Entity<Categorias>().HasData(
                new Categorias { Id = 1, Nome = "Categ 1", Descripcion = ""}
                );

            modelBuilder.Entity<Produtos>().HasData(
                new Produtos { Id = 1, Nome = "Prod 1", Preco = 2.00M, Estoque = 3, CategoriaId = 1 },
                new Produtos { Id = 2, Nome = "Prod 2", Preco = 3.00M, Estoque = 1 }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
