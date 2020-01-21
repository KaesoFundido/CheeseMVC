using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public CheeseCategory Category { get; set; }
        public int CategoryID { get; set; }
        public int Rating { get; set; }

        public IList<CheeseMenu> CheeseMenus { get; set; }

        internal static void Add(SelectListItem selectListItem)
        {
            throw new NotImplementedException();
        }
    }

}
