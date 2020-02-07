using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Infrastructure.Interfaces;

namespace ShopStudy.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService _cartServicecs;

        public CartsController(ICartService cartServicecs)
        {
            _cartServicecs = cartServicecs;
        }
        public IActionResult Details()
        {
            return View("Details", _cartServicecs.TransformCart());
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartServicecs.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartServicecs.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _cartServicecs.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartServicecs.AddToCart(id);
            return Redirect(returnUrl);
        }
    }
}
