using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalCSharpProject.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantData;

        // where did the IRestaurantData restaurantData come from?
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

       
        // if we don't return anything in OnGet, by default it will render the Detail.cshtml page
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page(); // this will render Detail.cshtml page
            
        }
    }
}
