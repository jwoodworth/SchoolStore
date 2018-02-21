using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolStore.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int? id=1)
        {
            Models.ProductsViewModel model = new Models.ProductsViewModel();



            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JimTest; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            var connection = new System.Data.SqlClient.SqlConnection(connectionString);

            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products WHERE PRODUCTID = " + id.Value;
            var reader = command.ExecuteReader();
            var idColumn = reader.GetOrdinal("ProductID");
            var nameColumn = reader.GetOrdinal("ProductName");
            var priceColumn = reader.GetOrdinal("Price");
            var sizeColumn = reader.GetOrdinal("ProductSize");
            var descriptionColumn = reader.GetOrdinal("ProductDescription");
            var imageUrlColumn = reader.GetOrdinal("ImageUrl");
            var colorColumn = reader.GetOrdinal("ProductColor");
            while (reader.Read())
            {
                model.Id = reader.GetInt32(idColumn);
                model.ProductName = reader.GetString(nameColumn);   //I can see name is the second column in the database.
                model.Price = reader.GetDecimal(priceColumn);
                model.ProductColor = reader.GetString(colorColumn);
                model.ProductSize = reader.GetString(sizeColumn);
                model.ProductDescription = reader.GetString(descriptionColumn);
                model.ImageUrl = reader.GetString(imageUrlColumn);
            }

            //model.Name = "Albert";
            //model.Price = 299.99m;
            //model.DietaryRequirements = "Grass, Hay, Carrots, Cap'n Crunch";
            //model.Description = "Albert is an absolutely perfect Alpaca";
            //model.Age = 4;
            //model.Temperment = "Pleasant";
            //model.ImageUrl = "/images/alpaca1.jpg";

            connection.Close();















            connection.Open();



            connection.Close();
            return View(model);

        }


//        [HttpPost]
//        public IActionResult Index(string id, bool? extraparm)
//        {
//            string cartId;
//            if (!Request.Cookies.ContainsKey("cartId"))
//            {
//                cartId = Guid.NewGuid().ToString();
//                Response.Cookies.Append("cartId", cartId, new Microsoft.AspNetCore.Http.CookieOptions
//                {
//                    Expires = DateTime.Now.AddYears(1)
//                });
//            }
//            else
//            {
//                Request.Cookies.TryGetValue("cartId", out cartId);
//            }
//            Console.WriteLine("Added {0} to cart {1}", id, cartId);
//            //TODO: 

//            //Cookies: useful for saving small amount of info
//            //Response.Cookies.Append("productsId", id);




//            return RedirectToAction("Index", "ProductConfiguration");
//        }

        //public IActionResult Index(int id)
        //{
        //    List<Models.ProductsViewModel> products = new List<Models.ProductsViewModel>();
        //    products.Add(new Models.ProductsViewModel()
        //    {
        //        Id = 1,
        //        ProductName = "T-Shirt",
        //        ProductColor = "Gray",
        //        ProductSize = "Small",
        //        Price = 15.75d,
        //        ProductDescription = "A classic shirt",
        //        ImageUrl = "./images/grayshirt.jpg"
        //    });
        //    products.Add(new Models.ProductsViewModel()
        //    {
        //        Id = 2,
        //        ProductName = "T-Shirt",
        //        ProductColor = "Black",
        //        ProductSize = "Large",
        //        Price = 18.50d,
        //        ProductDescription = "A modern shirt",
        //        ImageUrl = "./images/blackshirt.jpg"
        //    });
        //    products.Add(new Models.ProductsViewModel()
        //    {
        //        Id = 3,
        //        ProductName = "T-Shirt",
        //        ProductColor = "White",
        //        ProductSize = "X-Large",
        //        Price = 10.00d,
        //        ProductDescription = "An inexpensive shirt",
        //        ImageUrl = "./images/whiteshirt.jpg"
        //    });

        //    products.Find(     ==id)


        //}
    }
}