using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    public partial class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
        }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crusts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:kirbyrevature.database.windows.net,1433;Initial Catalog=PizzaBoxDb;User ID=dev;Password=AzureMonkey1994");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.Property(e => e.CrustId).ValueGeneratedNever();

                entity.Property(e => e.CrustName).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CustomerName).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_crusts");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_customers");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_pizzas");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_sizes");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_stores");

                entity.HasOne(d => d.Topping1)
                    .WithMany(p => p.OrderTopping1s)
                    .HasForeignKey(d => d.Topping1Id)
                    .HasConstraintName("FK_orders_toppings");

                entity.HasOne(d => d.Topping2)
                    .WithMany(p => p.OrderTopping2s)
                    .HasForeignKey(d => d.Topping2Id)
                    .HasConstraintName("FK_orders_toppings1");

                entity.HasOne(d => d.Topping3)
                    .WithMany(p => p.OrderTopping3s)
                    .HasForeignKey(d => d.Topping3Id)
                    .HasConstraintName("FK_orders_toppings2");

                entity.HasOne(d => d.Topping4)
                    .WithMany(p => p.OrderTopping4s)
                    .HasForeignKey(d => d.Topping4Id)
                    .HasConstraintName("FK_orders_toppings3");

                entity.HasOne(d => d.Topping5)
                    .WithMany(p => p.OrderTopping5s)
                    .HasForeignKey(d => d.Topping5Id)
                    .HasConstraintName("FK_orders_toppings4");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId).ValueGeneratedNever();

                entity.Property(e => e.PizzaName).IsUnicode(false);

                entity.HasOne(d => d.Topping1)
                    .WithMany(p => p.PizzaTopping1s)
                    .HasForeignKey(d => d.Topping1Id)
                    .HasConstraintName("FK_pizzas_toppings1");

                entity.HasOne(d => d.Topping2)
                    .WithMany(p => p.PizzaTopping2s)
                    .HasForeignKey(d => d.Topping2Id)
                    .HasConstraintName("FK_pizzas_toppings2");

                entity.HasOne(d => d.Topping3)
                    .WithMany(p => p.PizzaTopping3s)
                    .HasForeignKey(d => d.Topping3Id)
                    .HasConstraintName("FK_pizzas_toppings3");

                entity.HasOne(d => d.Topping4)
                    .WithMany(p => p.PizzaTopping4s)
                    .HasForeignKey(d => d.Topping4Id)
                    .HasConstraintName("FK_pizzas_toppings4");

                entity.HasOne(d => d.Topping5)
                    .WithMany(p => p.PizzaTopping5s)
                    .HasForeignKey(d => d.Topping5Id)
                    .HasConstraintName("FK_pizzas_toppings5");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId).ValueGeneratedNever();

                entity.Property(e => e.SizeName).IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.StoreName).IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.ToppingId).ValueGeneratedNever();

                entity.Property(e => e.ToppingName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
