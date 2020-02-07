using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;
using ShopStudy.NewDomain.FIlters;

namespace ShopStudy.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Shop(int? categoryId, int? brandId)
        {
            var products = _productService
                .GetProducts(new ProductFilter {BrandId = brandId, CategoryId = categoryId});
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    ImageURL = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };
            return View(model);
        }

        public IActionResult ProductDetail(int id)
        {
            var products = _productService.GetProductById(id);
            if (products == null)
                return NotFound();
            var model = new ProductViewModel()
            {
                Id = products.Id,
                ImageURL = products.ImageUrl,
                Name = products.Name,
                Order = products.Order,
                Price = products.Price,
                Brand = products.Brand?.Name ?? string.Empty
            };
            return View(model);
        }
    }
}
