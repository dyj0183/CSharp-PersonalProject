using System;
using System.Collections.Generic;
using System.Text;
using Food.Core;

namespace Food.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Jamal's Pizza", Location="Rexburg", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Sami's Pizza", Location="Provo", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 3, Name = "John's Pizza", Location="Lehi", Cuisine=CuisineType.Indian },
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {

        }
    }
}
