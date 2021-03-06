﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolStore.Models;


namespace SchoolStore.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly JimTestContext _context;

        public ProductCategoryController(JimTestContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? id, string color)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcategory = _context.ProductCategory.Include(x => x.Products).ThenInclude(x => x.Configurations).Include(x => x.ChildCategories).SingleOrDefault(m => m.ID == id);
            if (productcategory == null)
            {
                return NotFound();
            }

            return View(productcategory);
        }
    }
}