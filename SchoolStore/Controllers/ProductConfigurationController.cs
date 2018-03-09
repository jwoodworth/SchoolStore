using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolStore.Models;
//
//Old File do not use
//
namespace SchoolStore.Controllers
{
    public class ProductConfigurationController : Controller
    {   [HttpGet]  //can add but not required. This is default method
        public IActionResult Index()
        {

            string prodId = "test id";
            Request.Cookies.TryGetValue("productId", out prodId );
            ViewData["prodId"] = "prodcutId";
            
            ViewData["States"] = new string[] { "Alabama", "Alaska", "Arkansas" };
            ViewData["Colors"] = new string[] {"", "Blue", "Red", "Gray", "Green", "White" };
            ViewData["Sizes"] = new string[] {"", "Small", "Medium", "Large", "X-Large", "XX-Large" };
            return View();
        }
        [HttpPost]  //match names from parameter names from form and number
        [ValidateAntiForgeryToken]
        //public IActionResult Index(string productname, string productcolor, string productsize)
        // easier method below
        public IActionResult Index(ProductConfiguration model)
        {
            if (ModelState.IsValid)
            {
                //If model state is valid, proceed to the next step.
                return this.RedirectToAction("Index", "Home");
            }

            //Otherwise, redisplay the page!
            ViewData["States"] = new string[] { "Alabama", "Alaska", "Arkansas" };
            ViewData["Colors"] = new string[] {"", "Blue", "Red", "Gray", "Green", "White" };
            ViewData["Sizes"] = new string[] { "","Small", "Medium", "Large", "X-Large", "XX-Large" };
            return View(model);
        }

    }
}