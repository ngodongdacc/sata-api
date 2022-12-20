using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SATO.Entities.Entities;

namespace SATO.Infrastructure.Presistence
{
    public class SatoDbContext : DbContext
    {
        public SatoDbContext()
        {
        }

        public SatoDbContext(DbContextOptions<SatoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderitem> Orderitems { get; set; } = null!;
        public virtual DbSet<Ordertype> Ordertype { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Temp> Temps { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=satodb;uid=root;password=123456;treattinyasboolean=true;convertzerodatetime=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(45);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.BirthOfDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmployeeCode).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.UpdatedDate).HasMaxLength(45);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerId, "fk_orders_customers");

                entity.HasIndex(e => e.EmployeeId, "fk_orders_ordertype");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.OrderCode).HasMaxLength(20);

                entity.Property(e => e.OrderTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderTypeID");

                entity.Property(e => e.ShipAddress).HasColumnType("datetime");

                entity.Property(e => e.ShipName).HasMaxLength(45);

                entity.Property(e => e.ShippedDate).HasMaxLength(45);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_employee");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_ordertype");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.HasKey(e => e.OrderItemsId)
                    .HasName("PRIMARY");

                entity.ToTable("orderitems");

                entity.HasIndex(e => e.OrderId, "fk_orderitems_orders");

                entity.HasIndex(e => e.ProductId, "fk_orderitems_products");

                entity.Property(e => e.OrderItemsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderItemsID");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasPrecision(10, 2);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_orderitems_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_orderitems_products");
            });

            modelBuilder.Entity<Ordertype>(entity =>
            {
                entity.ToTable("ordertype");

                entity.Property(e => e.OrderTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTypeName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.CategoryId, "fk_products_categories");

                entity.HasIndex(e => e.ProviderId, "fk_products_providers");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Price).HasPrecision(10, 2);

                entity.Property(e => e.ProductCode).HasMaxLength(20);

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.ProviderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProviderID");

                entity.Property(e => e.Quantity).HasPrecision(10, 2);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_products_categories");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("fk_products_providers");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("providers");

                entity.Property(e => e.ProviderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProviderID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProviderCode).HasMaxLength(20);

                entity.Property(e => e.ProviderEmail).HasMaxLength(50);

                entity.Property(e => e.ProviderName).HasMaxLength(50);

                entity.Property(e => e.ProviderPhone).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().HasOne(p => p.Category).IsRequired();
            //modelBuilder.Entity<Product>().HasRequired(pd => pd.Product).WithMany(p => p.ProductDetails).HasForeignKey(pd => pd.ProductId).WillCascadeOnDelete(true);
            //OnModelCreatingPartial(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
