using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SchoolStore.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult List(int? color, int? size, int? category)
        {
            IEnumerable<ProductConfiguration> products = _context.ProductConfiguration;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (color.HasValue)
            {
                products = products.Where(x => x.ColorID == color);
            }

            var filteredProducts = _context.Products;


            return Json(filteredProducts);

            
        }


        public IActionResult Index(int id = 1)
        {

            var product = _context.Products
                .Include(x => x.Reviews)
                .Include(x => x.Configurations)
                    .ThenInclude(x => x.Color)
                .Include(x => x.Configurations)
                    .ThenInclude(x => x.Size)
                .Single(x => x.ID == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Index(int id, bool extraParam = true)
        {
            Guid cartID;
            Cart c;
            CartLineItem i;
            if (Request.Cookies.ContainsKey("cartID") && Guid.TryParse(Request.Cookies["cartID"], out cartID) && _context.Cart.Any(x => x.TrackingNumber == cartID))
            {
                c = _context.Cart
                    .Include(x => x.CartLineItems)
                    .ThenInclude(y => y.Product)
                    .Single(x => x.TrackingNumber == cartID);
            }
            else
            {
                c = new Cart();
                cartID = Guid.NewGuid();
                c.TrackingNumber = cartID;
                _context.Cart.Add(c);
            }

            if (User.Identity.IsAuthenticated)
            {
                c.User = _context.Users.Find(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            }

            if (c.CartLineItems.Any(x => x.Product.ID == id))
            {
                i = c.CartLineItems.FirstOrDefault(x => x.Product.ID == id);
            }
            else
            {
                i = new CartLineItem();
                i.Cart = c;
                i.Product = _context.Products.Find(id);
                c.CartLineItems.Add(i);
            }
            i.Quantity++;

            _context.SaveChanges();
            Response.Cookies.Append("cartID", c.TrackingNumber.ToString(),
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });



            return RedirectToAction("Index", "Shipping");
        }

    }
}