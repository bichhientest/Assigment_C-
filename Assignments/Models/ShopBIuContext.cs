using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignments.Models
{
    public partial class ShopBIuContext : DbContext
    {
        public ShopBIuContext()
        {
        }

        public ShopBIuContext(DbContextOptions<ShopBIuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCart> TbCarts { get; set; } = null!;
        public virtual DbSet<TbCartDetail> TbCartDetails { get; set; } = null!;
        public virtual DbSet<TbCategory> TbCategories { get; set; } = null!;
        public virtual DbSet<TbCustomer> TbCustomers { get; set; } = null!;
        public virtual DbSet<TbProduct> TbProducts { get; set; } = null!;
        public virtual DbSet<TbStaff> TbStaffs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NCEFE4N\\SQLEXPRESS01;Initial Catalog=Assigment;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Tb_Carts__D6AB47592620EC0E");

                entity.ToTable("Tb_Carts");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cart_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Tb_Carts__Custom__403A8C7D");
            });

            modelBuilder.Entity<TbCartDetail>(entity =>
            {
                entity.HasKey(e => e.CartDetailId)
                    .HasName("PK__Tb_Cart___85F0041B544954E8");

                entity.ToTable("Tb_Cart_Detail");

                entity.Property(e => e.CartDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("CartDetail_Id");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.TbCartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__Tb_Cart_D__Cart___4316F928");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TbCartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Tb_Cart_D__Produ__440B1D61");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Tb_Categ__6DB38D6ED622DDB2");

                entity.ToTable("Tb_Categories");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Name");

                entity.Property(e => e.Pictrue).HasMaxLength(255);
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Tb_Custo__8CB28699CA4BE262");

                entity.ToTable("Tb_Customers");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.Addresz).HasMaxLength(255);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Tb_Produ__9834FBBABD1443B5");

                entity.ToTable("Tb_Products");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Descriptions).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("Product_Name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Tb_Produc__Categ__3B75D760");
            });

            modelBuilder.Entity<TbStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__Tb_Staff__32D1F4237AD35131");

                entity.ToTable("Tb_Staff");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(7)
                    .HasColumnName("Staff_Id");

                entity.Property(e => e.Password).HasMaxLength(55);

                entity.Property(e => e.StaffName)
                    .HasMaxLength(55)
                    .HasColumnName("Staff_Name");

                entity.Property(e => e.Username).HasMaxLength(55);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
