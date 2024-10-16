using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoStatus> PedidoStatus { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.IdCategoria);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.PedidoItens)
                .WithOne(pi => pi.Pedido)
                .HasForeignKey(pi => pi.IdPedido);

            modelBuilder.Entity<PedidoStatus>()
                .HasMany(ps => ps.Pedidos)
                .WithOne(p => p.PedidoStatus)
                .HasForeignKey(p => p.IdPedidoStatus);

            modelBuilder.Entity<Produto>()
                .HasMany(p => p.PedidoItens)
                .WithOne(pi => pi.Produto)
                .HasForeignKey(pi => pi.IdProduto);
        }
    }
}
