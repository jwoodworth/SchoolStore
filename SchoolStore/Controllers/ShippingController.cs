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
        private Braintree.BraintreeGateway _braintreeGateway;

        public ShippingController(JimTestContext context, Braintree.BraintreeGateway braintreeGateway)
        {
            _context = context;
            _braintreeGateway = braintreeGateway;
        }


        [HttpGet]
        public IActionResult Index()
        {
            string cartID;
            Guid trackingNumber;
            ShippingViewModel model = new ShippingViewModel();
            if (Request.Cookies.TryGetValue("cartID", out cartID) && Guid.TryParse(cartID, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var cart = _context.Cart
                    .Include(x => x.CartLineItems)
                    .ThenInclude(y => y.ProductConfiguration)
                    .ThenInclude(y => y.Product)
                    .Include(x => x.CartLineItems)
                    .ThenInclude(y => y.ProductConfiguration)
                    .ThenInclude(y => y.Size)
                    .Include(x => x.CartLineItems)
                    .ThenInclude(y => y.ProductConfiguration)
                    .ThenInclude(y => y.Color)
                    .Single(x => x.TrackingNumber == trackingNumber);
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
                var cart = _context.Cart.Include(x => x.CartLineItems).ThenInclude(y => y.ProductConfiguration).Single(x => x.TrackingNumber == trackingNumber);
                var cartItem = cart.CartLineItems.Single(x => x.ProductConfiguration.ID == productID);
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
        public async Task<IActionResult> Index(ShippingViewModel model, string creditcardnumber, string creditcardname, string creditcardverificationvalue, string expirationmonth, string expirationyear)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            if (string.IsNullOrEmpty(model.ZipCode) || !regex.IsMatch(model.ZipCode))
            {
                ModelState.AddModelError("ZipCode", "This zip code is not valid");
            }

            if (ModelState.IsValid)
            {
                Braintree.TransactionRequest saleRequest = new Braintree.TransactionRequest();
                saleRequest.Amount = 10;    //Hard-coded for now
                saleRequest.CreditCard = new Braintree.TransactionCreditCardRequest
                {
                    CardholderName = creditcardname,
                    CVV = creditcardverificationvalue,
                    ExpirationMonth = expirationmonth,
                    ExpirationYear = expirationyear,
                    Number = creditcardnumber
                };
                var result = await _braintreeGateway.Transaction.SaleAsync(saleRequest);
                if (result.IsSuccess())
                {
                    //If model state is valid, proceed to the next step.
                    return this.RedirectToAction("Index", "Home");  //got to order complete page
                }
                foreach (var error in result.Errors.All())
                {
                    ModelState.AddModelError(error.Code.ToString(), error.Message);
                }
            }
            return View();
        }



    }
}