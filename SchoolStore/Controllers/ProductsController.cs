using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SchoolStore.Models;
using System.Data.SqlClient;

namespace SchoolStore.Controllers
{
    public class ProductsController : Controller
    {
        //private ConnectionStrings _connectionStrings;
        private JimTestContext _context;

        public ProductsController(JimTestContext context)
        {
            _context = context;
        }


        public IActionResult Index(int id = 1)
        {
            //ProductsViewModel model = new ProductsViewModel();

            var product = _context.Products.Find(id);
            return View(product);
        }
        //    using (var connection = new SqlConnection(_connectionStrings.DefaultConnection))
        //    {

        //        connection.Open();
        //        var command = connection.CreateCommand();

        //        //added stored procedure to prevent injection attacks
        //        command.CommandText = "sp_GetProduct";
        //        command.Parameters.AddWithValue("@id", id);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        using (var reader = command.ExecuteReader())
        //        {
        //            var idColumn = reader.GetOrdinal("ProductID");
        //            var nameColumn = reader.GetOrdinal("ProductName");
        //            var priceColumn = reader.GetOrdinal("Price");
        //            var sizeColumn = reader.GetOrdinal("ProductSize");
        //            var descriptionColumn = reader.GetOrdinal("ProductDescription");
        //            var imageUrlColumn = reader.GetOrdinal("ImageUrl");
        //            var colorColumn = reader.GetOrdinal("ProductColor");
        //            while (reader.Read())
        //            {
        //                model.Id = reader.GetInt32(idColumn);
        //                model.ProductName = reader.IsDBNull(nameColumn) ? "" : reader.GetString(nameColumn);   //well written ADO code tests for nulls
        //                model.Price = reader.IsDBNull(priceColumn) ? 0m : reader.GetDecimal(priceColumn);
        //                model.ProductColor = reader.GetString(colorColumn);
        //                model.ProductSize = reader.GetString(sizeColumn);
        //                model.ProductDescription = reader.GetString(descriptionColumn);
        //                model.ImageUrl = reader.GetString(imageUrlColumn);
        //            }
        //        }
        //        connection.Close();
        //    }

        //    return View(model);

        //}


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