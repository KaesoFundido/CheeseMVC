using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
          

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory = new CheeseCategory
                {
                    Name = viewModel.Name
                };
                context.Categories.Add(newCheeseCategory);
                context.SaveChanges();
                    
                return Redirect("/Category");
            }

            return View(viewModel);
        }        
    }
}
