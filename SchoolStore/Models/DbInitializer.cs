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
            if (!context.ProductCategory.Any())
            {
                context.ProductCategory.AddRange(new ProductCategory
                {
                    //ProductCategoryId = 1,
                    Name = "shirts"
                }, new ProductCategory
                {
                    //ProductCategoryId = 2,
                    Name = "sweatshirts"
                }, new ProductCategory
                {
                    //ProductCategoryId = 3,
                    Name = "hats"
                }
                );
                context.SaveChanges();
            }

            //Second Table
            if (!context.Products.Any())
            {
                context.Products.AddRange(new Products
                {
                    // ProductId = 100,
                    ProductName = "Black T-Shirt",
                    ProductDescription = "This is a great tshirt for work or home.",
                    ImageId = 1,
                    ProductCategoryId = context.ProductCategory.First(x => x.Name == "shirts").ProductCategoryId

                }, new Products
                {
                    //ProductId = 200,
                    ProductName = "Gray Sweatshirts",
                    ProductDescription = "Classic casual look.  you can not go wrong this choice.",
                    ImageId = 2,
                    ProductCategoryId = context.ProductCategory.First(x => x.Name == "sweatshirts").ProductCategoryId
                }, new Products
                {
                    //ProductId = 300,
                    ProductName = "Blue Baseball Cap",
                    ProductDescription = "A great looking hat.",
                    ImageId = 3,
                    ProductCategoryId = context.ProductCategory.First(x => x.Name == "hats").ProductCategoryId
                }

                );
                context.SaveChanges();
            }

            // Third Table to Load
            if (!context.Image.Any())
            {
                context.Image.AddRange(new Image
                {
                    //ImageID
                    ImageUrl = "/wwwroot/images/blackshirt.jpg",
                    ImageAltText = "black tshirt",
                }, new Image
                {
                    //ImageId
                    ImageUrl = "/wwwroot/images/graysweatshirt.jpg",
                    ImageAltText="gray sweatshirt"
                }, new Image
                {
                    //ImageID
                    ImageUrl = "/wwwroot/images/baseballcap.jpg",
                    ImageAltText = "blue baseball cap"
                }
                );
                context.SaveChanges();
            }
            //


            // 4th Table to Load
            if (!context.Review.Any())
            {
                context.Review.AddRange(new Review
                {
                    // ReviewId,
                    ProductId = 1,
                    CustomerId = 1,
                }, new Review
                {
                    //ReviewId = 200,
                    ProductId = 2,
                    CustomerId = 2,
                }
                );
                context.SaveChanges();
            }
            //


            // 5th Table to Load
            if (!context.ProductConfig.Any())
            {
                context.ProductConfig.AddRange(new ProductConfig
                {
                    // ProductConfigId
                    ProductId = 1,
                    ColorId = 1,
                    SizeId = 2
                }, new ProductConfig
                {
                    // ProductConfigId
                    ProductId = 3,
                    ColorId = 3,
                    SizeId = 3
                }, new ProductConfig
                {
                    // ProductConfigId
                    ProductId = 2,
                    ColorId = 2,
                    SizeId = 4
                }
                );
                context.SaveChanges();
            }
            //


            // 6th Table to Load
            if (!context.Size.Any())
            {
                context.Size.AddRange(new Size
                {
                    // SizeId ,
                    SizeName = "Youth Small",
                }, new Size
                {
                    //SizeId,
                    SizeName = "Youth Medium",
                }, new Size
                {
                    //SizeId = 300,
                    SizeName = "Youth Large",
                }, new Size
                {
                    //SizeId = 300,
                    SizeName = "Adult Sall",
                }
                );
                context.SaveChanges();
            }
            //

            // 7th Table to Load
            if (!context.Color.Any())
            {
                context.Color.AddRange(new Color
                {
                    // ColorId,
                    ColorName = "Black",
                    //ImageURL = "",
                    //DateCreated=""
                }, new Color
                {
                    //ColorId =,
                    ColorName = "Gray",
                    //ImageURL = "",
                    //DateCreated =
                }, new Color
                {
                    //ColorId =,
                    ColorName = "Blue",
                    //ImageURL = "",
                    //DateCreated =
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
                    // SalesOrderId,
                    BillToAddressId = 1,
                    Comment = "Please rush this order",
                    CustomerId = 1,
                    //DateCreated =
                    //DateLastModified =
                    //OrderDate = 
                   ShipCost = 100.00M,
                   //ShipDate
                   ShipToAddressId = 2,
                   ShipToMethod = "USPS",
                   SubTotal = 250.00M,
                   TaxAmount = 10.00M,
                   TotalDue = 360.00M
                }, new OrderHeader
                {
                    // SalesOrderId,
                    BillToAddressId = 3,
                    Comment = "Please rush this order",
                    CustomerId = 2,
                    //DateCreated =
                    //DateLastModified =
                    //OrderDate = 
                    ShipCost = 50.00M,
                    //ShipDate
                    ShipToAddressId = 1,
                    ShipToMethod = "Fed Ex",
                    SubTotal = 150.00M,
                    TaxAmount = 10.00M,
                    TotalDue = 210.00M
                }, new OrderHeader
                {
                    // SalesOrderId,
                    BillToAddressId = 2,
                    Comment = "Please hold this order",
                    CustomerId = 2,
                    //DateCreated =
                    //DateLastModified =
                    //OrderDate = 
                    ShipCost = 10.00M,
                    //ShipDate
                    ShipToAddressId = 3,
                    ShipToMethod = "Fed Ex",
                    SubTotal = 100.00M,
                    TaxAmount = 10.00M,
                    TotalDue = 120.00M
                }

                );
                context.SaveChanges();
            }
            //


            // 9th Table to Load
            //if (!context.OrderLineItem.Any())
            //{
            //    context.OrderLineItem.AddRange(new OrderLineItem
            //    {
            //        // ProductId,
            //        // LineItemId,
            //        ProductId = 1,
            //        ProductConfigId = 1,
            //        Quantity = 4,
            //        UnitPrice = 10.00M,
            //        LineItemTotal = 40.00M
            //    }, new OrderLineItem
            //    {
            //        // ProductId,
            //        // LineItemId,
            //        ProductId = 2,
            //        ProductConfigId = 2,
            //        Quantity = 2,
            //        UnitPrice = 15.50M,
            //        LineItemTotal = 31.00M
            //    }, new OrderLineItem
            //    {
            //        // ProductId,
            //        // LineItemId,
            //        ProductId = 3,
            //        ProductConfigId = 3,
            //        Quantity = 1,
            //        UnitPrice = 45.50M,
            //        LineItemTotal = 45.50M
            //    }
            //    );
            //    context.SaveChanges();
            //}
            //


            // 10th Table to Load
            if (!context.Cart.Any())
            {
                context.Cart.AddRange(new Cart
                {
                    // CartId = 100,
                    CookieId = "3d5rf397234khsdfshkhl",
                    CustomerId = 1,
                }, new Cart
                {
                    // CartId = 100,
                    CookieId = "3d5rf397234khsdfhelplmel",
                    CustomerId = 2,
                }, new Cart
                {
                    // CartId = 100,
                    CookieId = "3d5rf397234khelloworld13l",
                    CustomerId = 1,
                }
                );
                context.SaveChanges();
            }
            //

            // 11th Table to Load
            //if (!context.CartLineItem.Any())
            //{
            //    context.CartLineItem.AddRange(new CartLineItem
            //    {
            //        // CartId,
            //        // CartLineItemId,
            //        ProductId = 1,
            //        ProductConfigId = 1,
            //        Quantity = 4,
            //        UnitPrice = 10.00M,
            //        LineItemTotal = 40.00M
            //    }, new CartLineItem
            //    {
            //        // CartId,
            //        // CartLineItemId,
            //        ProductId = 2,
            //        ProductConfigId = 2,
            //        Quantity = 2,
            //        UnitPrice = 15.50M,
            //        LineItemTotal = 31.00M
            //    }, new CartLineItem
            //    {
            //        // ProductId,
            //        // LineItemId,
            //        ProductId = 3,
            //        ProductConfigId = 3,
            //        Quantity = 1,
            //        UnitPrice = 45.50M,
            //        LineItemTotal = 45.50M
            //    }

            //    );
            //    context.SaveChanges();
            //}
            //


            // 12th Table to Load
            if (!context.Cookie.Any())
            {
                context.Cookie.AddRange(new Cookie
                {
                    // CookieId = 100,
                    CookieString = "happybithdaytoyou123",
                }, new Cookie
                {
                    // CookieId = 100,
                    CookieString = "happynewyear2018",
                }, new Cookie
                {
                    //CookieId = 300,
                    CookieString = "gocubbiesgo987654",
                }
                );
                context.SaveChanges();
            }
            //


            // 13th Table to Load
            if (!context.Payment.Any())
            {
                context.Payment.AddRange(new Payment
                {
                    // PaymentId,
                    CreditCardNumber = "123456789",
                    PaymentCardType = "Visa",
                    PaymentMethod = "CreditCard",
                    //PaymentDate
                    SalesOrderId = 1,
                }, new Payment
                {
                    // PaymentId,
                    CreditCardNumber = "0031236111",
                    PaymentCardType = "MC",
                    PaymentMethod = "CreditCard",
                    //PaymentDate
                    SalesOrderId = 2,
                }
                );
                context.SaveChanges();
            }
            //


            // 14th Table to Load
            if (!context.Shipping.Any())
            {
                context.Shipping.AddRange(new Shipping
                {
                    // ShippingId,
                    SalesOrderId = 3,
                    //ShipDate ,
                    Shipper = "SpeeDee Delivery" 
                }, new Shipping
                {
                    // ShippingId,
                    SalesOrderId = 2,
                    //ShipDate ,
                    Shipper = "Uber"
                }
                );
                context.SaveChanges();
            }
            //

            // 15th Table to Load
            if (!context.Customer.Any())
            {
                context.Customer.AddRange(new Customer
                {
                    // CustomerId = 100,
                    FirstName = "Robert",
                    LastName = "Woodworth"
                }, new Customer
                {
                    // CustomerId = 100,
                    FirstName = "Amy",
                    LastName = "Smith"
                }, new Customer
                {
                    //CustomerId = 300,
                    FirstName = "Luke",
                    LastName="SKywalker"
                }
                );
                context.SaveChanges();
            }
            //


            // 16th Table to Load
            //if (!context.CustomerAddress.Any())
            //{
            //    context.CustomerAddress.AddRange(new CustomerAddress
            //    {
            //        CustomerId = 1,
            //        AddressId = 1,
            //        AddressType = "Shipping"
            //    }, new CustomerAddress
            //    {
            //        CustomerId = 1,
            //        AddressId = 2,
            //        AddressType = "Billing"
            //    }
            //    );
            //    context.SaveChanges();
            //}
            //


            // 17th Table to Load
            if (!context.Address.Any())
            {
                context.Address.AddRange(new Address
                {
                    //AddressID
                    AddressLine1 = "123 Main St",
                    AddressLine2 = "Apt 4G",
                    City = "Chicago",
                    State = "IL",
                    ZipCode = "60064"
                }, new Address
                {
                    //AddressID
                    AddressLine1 = "928 Apple Ave",
                    AddressLine2 = "Apt D",
                    City = "Libertyville",
                    State = "IL",
                    ZipCode = "60048"
                }, new Address
                {
                    //AddressID
                    AddressLine1 = "2521 Irving Ave S Apple Ave",
                    AddressLine2 = "",
                    City = "Minneapolis",
                    State = "MN",
                    ZipCode = "55405"
                }

                );
                context.SaveChanges();
            }
            //
        }
    }
}
