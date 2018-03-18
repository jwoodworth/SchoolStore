using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SchoolStore.Controllers
{
    public class ShippingController : Controller
    {

        private JimTestContext _context;
        private Braintree.BraintreeGateway _braintreeGateway;
        private SignInManager<ApplicationUser> _signInManager;
        private SmartyStreets.USStreetApi.Client _usStreetClient;

        public ShippingController(JimTestContext context, 
            Braintree.BraintreeGateway braintreeGateway,
            SignInManager<ApplicationUser> signInManager,
            SmartyStreets.USStreetApi.Client usStreetClient)
        {
            _context = context;
            _braintreeGateway = braintreeGateway;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Index()
        {
            ShippingViewModel model = new ShippingViewModel();

            

            await SetupViewAsync(model);
            return View(model);
        }

        private async Task SetupViewAsync(ShippingViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                Braintree.CustomerSearchRequest customerSearch = new Braintree.CustomerSearchRequest();
                var user = await _signInManager.UserManager.FindByIdAsync(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                customerSearch.Email.Is(user.Email);

                //this is the problem line returns null
                var customers = await _braintreeGateway.Customer.SearchAsync(customerSearch);

                if (customers.Ids.Any())
                {
                    var customer = customers.FirstItem;
                    model.SavedCreditCards = customer.CreditCards.Select(x => new SavedCreditCard { Token = x.Token, LastFour = x.LastFour }).ToArray();
                }
                else
                {
                    model.SavedCreditCards = new SavedCreditCard[0];
                }

                model.Email = user.Email;
            }
            string cartID;
            Guid trackingNumber;
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
        }

        [HttpPost]
        public IActionResult Update(int quantity, int productID )
        {
           
            string cartID;
            Guid trackingNumber;
            if (Request.Cookies.TryGetValue("cartID", out cartID) && Guid.TryParse(cartID, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var c = _context.Cart
                     .Include(x => x.CartLineItems)
                     .ThenInclude(y => y.ProductConfiguration)
                     .ThenInclude(z => z.Product)
                     .Single(x => x.TrackingNumber == trackingNumber);

                var cartItem = c.CartLineItems.Single(x => x.ProductConfiguration.ID == productID);
                
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
        public async Task<IActionResult> Index(ShippingViewModel model)
        {

            await SetupViewAsync(model);
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            if (string.IsNullOrEmpty(model.ShippingZipCode) || !regex.IsMatch(model.ShippingZipCode))
            {
                ModelState.AddModelError("ZipCode", "Invalid ZipCode");
            }
            
            if (ModelState.IsValid)
            {
                Braintree.CustomerSearchRequest customerSearch = new Braintree.CustomerSearchRequest();
                customerSearch.Email.Is(model.Email);
                Braintree.Customer customer = null;
                var customers = await _braintreeGateway.Customer.SearchAsync(customerSearch);
                if (customers.Ids.Any())
                {
                    customer = customers.FirstItem;
                }
                else
                {
                    Braintree.CustomerRequest newCustomer = new Braintree.CustomerRequest
                    {
                        Email = model.Email
                    };
                    var creationResult = await _braintreeGateway.Customer.CreateAsync(newCustomer);
                    customer = creationResult.Target;
                }
                if (string.IsNullOrEmpty(model.CardToken))
                {
                    Braintree.CreditCard card = null;
                    if (customer.CreditCards.Any())
                    {
                        string lastFour = new string(model.CreditCardNumber.Skip(model.CreditCardNumber.Length - 4).ToArray());

                        card = customer.CreditCards.FirstOrDefault(
                            x => x.ExpirationMonth == model.ExpirationMonth &&
                            x.ExpirationYear == model.ExpirationYear &&
                            x.LastFour == lastFour);
                    }
                    if (card == null)
                    {
                        Braintree.CreditCardRequest newCard = new Braintree.CreditCardRequest
                        {
                            CustomerId = customer.Id,
                            CardholderName = model.CreditCardName,
                            CVV = model.CreditCardVerificationValue,
                            ExpirationMonth = model.ExpirationMonth,
                            ExpirationYear = model.ExpirationYear,
                            Number = model.CreditCardNumber
                        };
                        var creationResult = await _braintreeGateway.CreditCard.CreateAsync(newCard);
                        card = creationResult.Target;
                        model.CardToken = card.Token;
                    }
                }

                Braintree.TransactionRequest saleRequest = new Braintree.TransactionRequest();
                saleRequest.Amount = model.CartLineItem.Sum(x => (x.ProductConfiguration.Product.UnitPrice * x.Quantity ?? .99m));

                saleRequest.CustomerId = customer.Id;
                saleRequest.PaymentMethodToken = model.CardToken;
                saleRequest.BillingAddress = new Braintree.AddressRequest
                {
                    StreetAddress = model.BillingAddress,
                    PostalCode = model.BillingZipCode,
                    Region = model.BillingState,
                    Locality = model.BillingCity,
                    CountryName = "United States of America",
                    CountryCodeAlpha2 = "US",
                    CountryCodeAlpha3 = "USA",
                    CountryCodeNumeric = "840"
                };

                var result = await _braintreeGateway.Transaction.SaleAsync(saleRequest);
                if (result.IsSuccess())
                {
                    //If model state is valid convert to order and show reciept
                    return this.RedirectToAction("Index", "Receipt");
                }

                foreach (var error in result.Errors.All())
                {
                    ModelState.AddModelError(error.Code.ToString(), error.Message);
                }

            }
            return View(model);
        }
    }
}