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
        private SmartyStreets.USStreetApi.Client _usStreetClient;

        public ShippingController(JimTestContext context, Braintree.BraintreeGateway braintreeGateway, SmartyStreets.USStreetApi.Client usStreetClient)
        {
            _context = context;
            _braintreeGateway = braintreeGateway;
            _usStreetClient = usStreetClient;
        }

        public IActionResult ValidateAddress(string street = "222 W Ontario", string city = "Chicago", string state = "IL")
        {
            SmartyStreets.USStreetApi.Lookup lookup = new SmartyStreets.USStreetApi.Lookup();
            lookup.Street = street;
            lookup.City = city;
            lookup.State = state;
            _usStreetClient.Send(lookup);
            return Json(lookup.Result);
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
                //var cartItem = cart.CartLineItems.Single(x => x.ProductConfiguration.ID == productID);
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
                    //pull in cart info form class





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