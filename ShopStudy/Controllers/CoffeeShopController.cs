using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;


namespace ShopStudy.Controllers
{
    public class CoffeeShopController : Controller
    {
        //Инициализация
        #region 
        private ICrud<CoffeeShopViewModel> _coffeeShopServices;
        public CoffeeShopController(ICrud<CoffeeShopViewModel> crud)
        {
            _coffeeShopServices = crud;
        }
        #endregion

        [HttpGet]
        [Route("CoffeeShop")]
        public IActionResult CoffeeMain()
        {
            return View(_coffeeShopServices.GetAll());
        }

        [HttpGet]
        [Route("CoffeeShop/{id}")]
        public IActionResult CoffeeDetails(int id)
        {
            var coffee = _coffeeShopServices.GetById(id);
            if (coffee == null)
                return NotFound();
            return View(coffee);
        }
        [HttpGet]
        [Route("Edit/{id?}")]
        public IActionResult CoffeeEdit(int? id)
        {
            if (!id.HasValue)
                return View(new CoffeeShopViewModel());
            var viewModel = _coffeeShopServices.GetById(id.Value);
            if (viewModel == null)
                return NotFound();
            return View(viewModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeShopServices.Delete(id);
            return RedirectToAction(nameof(CoffeeMain));
        }
        [HttpPost]
        [Route("Edit/{id?}")]
        public IActionResult Edit(CoffeeShopViewModel model)
        {
            if (model.Id > 0)
            {
                var dbItem = _coffeeShopServices.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();
                dbItem.ProductName = model.ProductName;
                dbItem.ProductCategory = model.ProductCategory;
                dbItem.ProductCost = model.ProductCost;
                dbItem.ProductSale = model.ProductSale;
                dbItem.ProductRating = model.ProductRating; 
                dbItem.Storage = model.Storage;
            }
            else
            {
                _coffeeShopServices.AddNew(model);
            }
            _coffeeShopServices.Commit();
            return RedirectToAction(nameof(CoffeeMain));
        }
    }
}
