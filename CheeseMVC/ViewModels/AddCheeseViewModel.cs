using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a description")]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories) 
        { 
            if(categories != null)
            {
                Categories = new List<SelectListItem>();

                foreach( var cat in categories)
                {
                    Categories.Add(new SelectListItem { 

                    Value = cat.ID.ToString(),
                    Text= cat.Name,

                    });
            }
            }
        }
        public AddCheeseViewModel()
        {
       
                
            

            

         
        }

        

    }
}
