using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Add(AddMenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
            Menu newMenu = new Menu
            {
                Name= vm.Name

            };
                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);

            }
            return View(vm);
        }
        
        [HttpGet]
        public IActionResult ViewMenu(int id)
        {
            Menu menu = context.Menus.Single(c => c.ID == id);
            
            List<CheeseMenu> items = context
            .CheeseMenus
            .Include(item => item.Cheese)
            .Where(cm => cm.MenuID == id)
            .ToList();

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel();

            viewMenuViewModel.Menu = menu;
            viewMenuViewModel.Items = items;
            
            return View(viewMenuViewModel);
        }
        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(c => c.ID == id);

            AddMenuItemViewModel addMenuItem = new AddMenuItemViewModel(menu, context.Cheeses);

            return View(addMenuItem);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel vm)
        {
            if (ModelState.IsValid)
            {

                IList<CheeseMenu> existingItems = context.CheeseMenus
                .Where(cm => cm.CheeseID == vm.cheeseID)
                .Where(cm => cm.MenuID == vm.menuID).ToList();

                if (!existingItems.Any())
                {
                    CheeseMenu newCm = new CheeseMenu
                    {
                        CheeseID = vm.cheeseID,
                        MenuID = vm.menuID
                    };

                    context.CheeseMenus.Add(newCm);
                    context.SaveChanges();

                    return Redirect("/Menu/ViewMenu/" + newCm.MenuID);
                }

            }
            return View(vm);
        }
    }
    
}
