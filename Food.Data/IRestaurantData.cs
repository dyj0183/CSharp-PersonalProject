using System;
using System.Collections.Generic;
using System.Text;
using Food.Core;
using System.Linq;

namespace Food.Data
{
    public interface IRestaurantData
    {
        //what is IEnumerable?
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        // constructor
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Jamal's Pizza", Location="Rexburg", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Sami's Pizza", Location="Provo", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 3, Name = "John's Pizza", Location="Lehi", Cuisine=CuisineType.Indian },
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            // use LINQ here
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            // use LINQ here, the default would be null if we can't find any matched id
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        // update
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // first, find the correct restaurant to work with
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant == null)
            {
                return null;
            }

            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
