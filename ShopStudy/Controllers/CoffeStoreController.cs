using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ShopStudy.Controllers
{
    public class CoffeStoreController : Controller
    {
        public IActionResult CoffeMain()
        {
            return View();
        }
    }
}
