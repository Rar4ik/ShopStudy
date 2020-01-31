using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;

namespace ShopStudy.ViewComponents
{
    [ViewComponent(Name = "Brand")]
    public class BrandsViewComponents : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponents(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brand = GetBrands();
            return View(brand);
        }

        private List<BrandViewModel> GetBrands()
        {
            var brands = _productService.GetBrands();
            var brandsList = new List<BrandViewModel>();
            foreach (var localBrand in brands)
            {
                brandsList.Add(new BrandViewModel()
                {
                    Id = localBrand.Id,
                    Order = localBrand.Order,
                    Name = localBrand.Name,
                    Amount = localBrand.Amount
                });
            }

            brandsList = brandsList.OrderBy(p => p.Order).ToList();
            return brandsList;
        }
    }
}
