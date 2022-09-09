using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class PizzariaContext : DbContext
    {
        public PizzariaContext()
        {
        }

        public PizzariaContext(DbContextOptions<PizzariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<EnderecoCliente> EnderecoClientes { get; set; }
        public virtual DbSet<ItemPedido> ItemPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CUUFG5\\SQLEXPRESS; Database=Pizzaria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnderecoCliente>(entity =>
            {
                entity.ToTable("EnderecoCliente");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.EnderecoClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_EnderecoCliente_Cliente");
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.ToTable("ItemPedido");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPedido_Pedido");

                entity.HasOne(d => d.IdPizza1Navigation)
                    .WithMany(p => p.ItemPedidoIdPizza1Navigations)
                    .HasForeignKey(d => d.IdPizza1)
                    .HasConstraintName("FK_ItemPedido_Pizza");

                entity.HasOne(d => d.IdPizza2Navigation)
                    .WithMany(p => p.ItemPedidoIdPizza2Navigations)
                    .HasForeignKey(d => d.IdPizza2)
                    .HasConstraintName("FK_ItemPedido_Pizza1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Pizza1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pizza");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
