using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        
        
        // GET: Menu /<controller>/
        public IActionResult Index()
        {
            List<Menu> menuList = context.Menus.ToList();
                return View(menuList);
        }

        public IActionResult Add()
        {
            AddMenuViewModel vm = new AddMenuViewModel();

            return View(vm);
        }


        public IActionResult ViewMenu()
        {
            return View();
        }
    }
}