using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolStore.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolStore.Controllers
{
    public class ShippingController : Controller
    {

        private JimTestContext _context;

        public ShippingController(JimTestContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            string cartID;
            Guid trackingNumber;
            ShippingViewModel model = new ShippingViewModel();
            if (Request.Cookies.TryGetValue("cartID", out cartID) && Guid.TryParse(cartID, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var cart = _context.Cart.Include(x => x.CartLineItems).ThenInclude(y => y.Product).Single(x => x.TrackingNumber == trackingNumber);
                model.CartLineItem = cart.CartLineItems.ToArray();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int quantity, int productID)
        {
            string cartID;
            Guid trackingNumber;
            if (Request.Cookies.TryGetValue("cartID", out cartID) && Guid.TryParse(cartID, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var cart = _context.Cart.Include(x => x.CartLineItems).ThenInclude(y => y.Product).Single(x => x.TrackingNumber == trackingNumber);
                var cartItem = cart.CartLineItems.Single(x => x.Product.ID == productID);
                cartItem.Quantity = quantity;

                if(cartItem.Quantity == 0)
                {
                    _context.CartLineItem.Remove(cartItem);
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ShippingViewModel model)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            if (string.IsNullOrEmpty(model.ZipCode) || !regex.IsMatch(model.ZipCode))
            {
                ModelState.AddModelError("ZipCode", "This zip code is not valid");
            }

            if (ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }



    }
}