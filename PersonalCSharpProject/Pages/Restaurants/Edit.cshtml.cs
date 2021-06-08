using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonalCSharpProject.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if(restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            } 
            else
            {
                Restaurant = new Restaurant();
            }
          
            if (Restaurant == null)
            {
                // if we couldn't find any restaurant by using the id, then we need to redirect back to the main List page
                return RedirectToPage("./List");
            }
            return Page(); // reneder to the Edit.cshtml page

        }

        public IActionResult OnPost()
        {
            // check if it passes all the validation check which was defined in Restaurant.cs
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
         
            if (Restaurant.Id <= 0)
            {
                restaurantData.Add(Restaurant);
            } 
            else
            {
                restaurantData.Update(Restaurant);
               
            }

            restaurantData.Commit();
            TempData["Message"] = "Restaurant Created Successfully!"; // temporary data, any page can access it
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
