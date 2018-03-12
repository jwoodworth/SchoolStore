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
                ProductCategory clothes = new ProductCategory();
                clothes.Name = "Clothes";
                context.ProductCategory.AddRange(clothes,
                    new ProductCategory
                {
                    //ProductCategoryId = 1,
                    Name = "T-Shirts",
                    ParentProductCategory = clothes
                }, new ProductCategory
                {
                    //ProductCategoryId = 2,
                    Name = "Sweatshirts",
                    ParentProductCategory = clothes
                }, new ProductCategory
                {
                    //ProductCategoryId = 3,
                    ParentProductCategory = clothes,
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
                    UnitPrice = 15.5M,
                    Category = context.ProductCategory.First(x => x.Name == "T-Shirts")
                }, new Products
                {
                    ProductName = "Performance T-Shirt",
                    ProductDescription = "Cool, wicking fabric to keep you dry in all activities",
                    UnitPrice = 18.75M,
                    Category = context.ProductCategory.First(x => x.Name == "T-Shirts")
                }, new Products
                {
                    ProductName = "Sweatshirt",
                    ProductDescription = "Classic comfortable sweatshirt ",
                    UnitPrice = 25.00M,
                    Category = context.ProductCategory.First(x => x.Name == "Sweatshirts")
                }, new Products
                {
                    ProductName = "Hoodie Sweatshirts",
                    ProductDescription = "A great hooded sweatshirt. You can not go wrong this choice.",
                    UnitPrice = 32.75M,
                    Category = context.ProductCategory.First(x => x.Name == "Sweatshirts")
                }, new Products
                {
                    ProductName = "Baseball Cap",
                    ProductDescription = "Sporty look.  Go Cubs!!",
                    UnitPrice = 20.75M,
                    Category = context.ProductCategory.First(x => x.Name == "Hats")
                }, new Products
                {
                    ProductName = "Candy Cane Hat",
                    ProductDescription = "Add some fun headwear anytime. ",
                    UnitPrice = 23.00M,
                    Category = context.ProductCategory.First(x => x.Name == "Hats")
                }, new Products
                {
                    ProductName = "Crab Hat",
                    ProductDescription = "Fun crabby hat. ",
                    UnitPrice = 33.00M,
                    Category = context.ProductCategory.First(x => x.Name == "Hats")
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
                    Name = "Adult Small",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult Medium",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult Large",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult XLarge",
                }, new Size
                {
                    //SizeId = 300,
                    Name = "Adult XXlarge",
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
                }, new Color
                {
                    //ID = 6,
                    Name = "One Color Only",
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
                    ImageURL = "/images/blackshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 7,
                    Inventory = 3,
                    ImageURL = "/images/blackshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 2,
                    SizeID = 3,
                    Inventory = 5,
                    ImageURL = "/images/grayshirt.jpg",
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
                    SizeID = 6,
                    Inventory = 7,
                    ImageURL = "/images/grayshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 5,
                    Inventory = 7,
                    ImageURL = "/images/blackshirtperformance.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 2)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 3,
                    Inventory = 5,
                    ImageURL = "/images/blackshirtperformance.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 2)
                }, new ProductConfiguration
                {
                    ColorID = 2,
                    SizeID = 4,
                    Inventory = 10,
                    ImageURL = "/images/graysweatshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 3)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 6,
                    Inventory = 7,
                    ImageURL = "/images/blacksweatshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 3)
                }, new ProductConfiguration
                {
                    ColorID = 2,
                    SizeID = 1,
                    Inventory = 7,
                    ImageURL = "/images/grayhoodsweatshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 4)
                }, new ProductConfiguration
                {
                    ColorID = 1,
                    SizeID = 2,
                    Inventory = 3,
                    ImageURL = "/images/blackhoodsweatshirt.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 4)
                }, new ProductConfiguration
                {
                    ColorID = 5,
                    SizeID = 3,
                    Inventory = 5,
                    ImageURL = "/images/bluebaseballcap.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 5)
                }, new ProductConfiguration
                {
                    ColorID = 6,
                    SizeID = 8,
                    Inventory = 10,
                    ImageURL = "/images/crabbyhat.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }, new ProductConfiguration
                {
                    ColorID = 4,
                    SizeID = 6,
                    Inventory = 7,
                    ImageURL = "/images/candycanehat.jpg",
                    Product = context.Products.SingleOrDefault(x => x.ID == 1)
                }
                );
                context.SaveChanges();
            }
            //
         
         }
    }
}
