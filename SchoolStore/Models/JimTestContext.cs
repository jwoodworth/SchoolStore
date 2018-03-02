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
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }
        public virtual DbSet<OrderLineItem> OrderLineItem { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductConfiguration> ProductConfiguration { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Size> Size { get; set; }

        //Add a new Virtual DbSet of your object to the context
        public virtual DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //This is called Fluent API - it allows for more specific customization of database rules
            modelBuilder.Entity<OrderHeader>().HasKey(prop => prop.ID);
            modelBuilder.Entity<OrderHeader>()
                .Property(prop => prop.ID)
                .ValueGeneratedOnAdd();

            //Fluent API can almost be translated into a sentance:
            //Order Has Property Tracking Number whose value is generated when added
            modelBuilder.Entity<OrderHeader>().Property(prop => prop.TrackingNumber)
               .ValueGeneratedOnAdd();

            //Order has many line items, each line item has an order, which is required
            modelBuilder.Entity<OrderHeader>().HasMany(o => o.OrderLineItems).WithOne(l => l.OrderHeader).IsRequired();

            //Line items have one order, with many line items.
            modelBuilder.Entity<OrderLineItem>().HasOne(l => l.OrderHeader).WithMany(o => o.OrderLineItems);
            modelBuilder.Entity<OrderLineItem>().HasOne(l => l.Product).WithMany(o => o.OrderLineItems);

            modelBuilder.Entity<Products>().HasMany(p => p.OrderLineItems).WithOne(l => l.Product).IsRequired();
        }
    }
}
