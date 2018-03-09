using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolStore.Models;
using Microsoft.EntityFrameworkCore;


//Add enough data to walk through several examples of shopping

namespace SchoolStore.Models
{
    internal class DbInitializer
    {
        internal static void Initialize(JimTestContext context)
        {
            //before seeding
            context.Database.Migrate();

            //Once created, start adding records   First Table
            if (!context.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Jim",
                    Email = "jgwoodworth@gmail.com"
                };

                context.SaveChanges();
            }

            if (!context.ProductCategory.Any())
            {
                context.ProductCategory.AddRange(new ProductCategory
                {
                    //ProductCategoryId = 1,
                    Name = "T-Shirts"
                }, new ProductCategory
                {
                    //ProductCategoryId = 2,
                    Name = "Sweatshirts"
                }, new ProductCategory
                {
                    //ProductCategoryId = 3,
                    Name = "Hats"
                }
                );
                context.SaveChanges();
            }

            //Second Table
            if (!context.Products.Any())
            {
                context.Products.AddRange(new Products
                {
                    ProductName = "Cotton T-Shirt",
                    ProductDescription = "This is a great T-Shirt for work or home.",
                    //Category = context.ProductCategory.First(x => x.Name == "T-Shirts"),
                    UnitPrice = 15.5M
                }, new Products
                {
                    ProductName = "Hoodie Sweatshirts",
                    ProductDescription = "Classic casual look.  You can not go wrong this choice.",
                    //Category = context.ProductCategory.First(x => x.Name == "Sweatshirt"),
                    UnitPrice = 25.75M
                }, new Products
                {
                    ProductName = "Baseball Cap",
                    ProductDescription = "Sporty look.  Go Cubs!! ",
                    //Category = context.ProductCategory.First(x => x.Name == "Hats"),
                    UnitPrice = 12.00M
                }

                );
                context.SaveChanges();
            }

            

            // 4th Table to Load
            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(new Review
                {
                    // ReviewId,
                    Rating = 5,
                    Body = "Great Product!  I love it.",
                    IsApproved = true,
                    Product = context.Products.First(),
                }, new Review
                {
                    // ReviewId,
                    Rating = 3,
                    Body = "This product is OK",
                    IsApproved = true,
                    Product = context.Products.First(),
                }

                );
                context.SaveChanges();
            }
            //


            //   Table to Load
            if (!context.Size.Any())
            {
                context.Size.AddRange(new Size
                {
                    // SizeId ,
                    Name = "Youth Small",
                }, new Size
                {
                    //SizeId,
                    Name = "Youth Medium",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Youth Large",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Youth Xlarge",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult Medium",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult Xlarge",
                }
                );
                context.SaveChanges();
            }
            //

            // Table to Load
            if (!context.Color.Any())
            {
                context.Color.AddRange(new Color
                {
                    //ID = 1,
                    Name = "Black"
                }, new Color
                {
                    //ID = 2,
                    Name = "Gray",
                }, new Color
                {
                    //ID = 3,
                    Name = "White",
                }, new Color
                {
                    //ID = 4,
                    Name = "Red",
                }, new Color
                {
                    //ID = 5,
                    Name = "Blue",
                }
                );
                context.SaveChanges();
            }
            //


            //  Table to Load
            if (!context.ProductConfiguration.Any())
            {
                context.ProductConfiguration.AddRange(new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 1,
                    Inventory = 5,
                    ImageURL = "/images/graysweatshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 2)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 2,
                    Inventory = 3,
                    ImageURL = "/images/blackshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 3,
                    Inventory = 5,
                    ImageURL = "/images/blackshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 2,
                    SizeID = 4,
                    Inventory = 10,
                    ImageURL = "/images/grayshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 2,
                    SizeID = 1,
                    Inventory = 7,
                    ImageURL = "/images/grayshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 2)
                }
                );
                context.SaveChanges();
            }
            //


            // 8th Table to Load
            if (!context.OrderHeader.Any())
            {
                context.OrderHeader.AddRange(new OrderHeader    
                {
                   BillToAddressId = 1,
                   ShipCost = 100.00M,
                   ShipToAddressId = 2,
                   SubTotal = 250.00M,
                   TaxAmount = 10.00M,
                   TotalDue = 360.00M,
                   TrackingNumber = Guid.NewGuid(),
                  // User = context.Users.First(x => x.UserName == "jim" )
                }               
                );
                context.SaveChanges();
            }
         
         }
    }
}
