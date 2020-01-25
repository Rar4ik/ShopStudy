using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Data;
using ShopStudy.Models;


namespace ShopStudy.Controllers
{
    public class CoffeeShopController : Controller
    {
        private List<CoffeeShopViewModel> GetCoffeeShopData()
        {
            CoffeeShopData coffeeShop = new CoffeeShopData();
            var coffeeShopData = coffeeShop.SendCoffeeShopData();
            return coffeeShopData;
        }
        public IActionResult CoffeeMain()
        {
            return View(GetCoffeeShopData());
        }

        public IActionResult CoffeeDetails(int id)
        {
            var coffee = GetCoffeeShopData().FirstOrDefault(x => x.Id == id);
            if (coffee == null)
                return NotFound();
            return View(coffee);
        }
    }
}
