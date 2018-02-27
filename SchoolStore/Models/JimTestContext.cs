using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolStore.Models
{
    public partial class JimTestContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser>
    {
        public JimTestContext(): base()
        {

        }

        public JimTestContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartLineItem> CartLineItem { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Cookie> Cookie { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }
        public virtual DbSet<OrderLineItem> OrderLineItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductConfig> ProductConfig { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Size> Size { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1).HasMaxLength(100);

                entity.Property(e => e.AddressLine2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(25);
            });

            

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CookieId)
                    .HasColumnName("CookieID")
                    .HasMaxLength(1000);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CartLineItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.LineItemId });

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.LineItemId).HasColumnName("LineItemID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LineItemTotal).HasColumnType("money");

                entity.Property(e => e.ProductConfigId).HasColumnName("ProductConfigID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ColorName).HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Cookie>(entity =>
            {
                entity.Property(e => e.CookieId).HasColumnName("CookieID");

                entity.Property(e => e.CookieString).HasMaxLength(1000);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId });

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressType).HasMaxLength(50);

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customer");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageAltText).HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<OrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId);

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.CreditCardapprovalCode).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShipCost).HasColumnType("money");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");

                entity.Property(e => e.ShipToMethod).HasMaxLength(100);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.TotalDue).HasColumnType("money");
            });

            modelBuilder.Entity<OrderLineItem>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.LineItemId });

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.LineItemId).HasColumnName("LineItemID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LineItemTotal).HasColumnType("money");

                entity.Property(e => e.ProductConfigId).HasColumnName("ProductConfigID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CreditCardNumber).HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentCardType).HasMaxLength(100);

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMethod).HasMaxLength(100);

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            });

 

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductConfig>(entity =>
            {
                entity.Property(e => e.ProductConfigId).HasColumnName("ProductConfigID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");
            });

            modelBuilder.Entity<Products>(entity =>
            {

                    entity.Property(e => e.ID).HasColumnName("ProductsID");

                    entity.Property(e => e.DateCreated)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.DateLastModified)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.ImageId).HasColumnName("ImageID");

                    entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                    entity.Property(e => e.ProductDescription).HasMaxLength(1000);

                    entity.Property(e => e.ProductName).HasMaxLength(200);

                    entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                    entity.Property(e => e.UnitPrice).HasColumnType("money");
                });


            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.Property(e => e.ShippingId).HasColumnName("ShippingID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Shipper).HasMaxLength(100);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SizeName).HasMaxLength(100);
            });
        }
    }
}
