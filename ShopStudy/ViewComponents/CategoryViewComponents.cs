using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;

namespace ShopStudy.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponents : ViewComponent
    {
        private readonly IProductService _productService;

        public CategoryViewComponents(IProductService productService)
        {
            _productService = productService;
        }    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Category = GetCategories();
            return View(Category);
        }

        private List<CategoryViewModel> GetCategories()
        {
            var categories = _productService.GetCategories();

            var parentSections = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();

            foreach (var parentCategory in parentSections)
            {
                parentCategories.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategories = null
                });
            }
            foreach (var categoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(c => c.ParentId == categoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    categoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategories = categoryViewModel
                    });
                }
                categoryViewModel.ChildCategories = categoryViewModel.ChildCategories.OrderBy(c => c.Order).ToList();
            }

            parentCategories = parentCategories.OrderBy(c => c.Order).ToList();
            return parentCategories;
        }
    }
}
