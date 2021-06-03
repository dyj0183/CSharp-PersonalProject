using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Food.Data;
using Food.Core;

namespace PersonalCSharpProject.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        // use model binding to grab data from the user input in the search form 
        public void OnGet()
        {
            Message = "Hello World";
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            
        }
    }
}
