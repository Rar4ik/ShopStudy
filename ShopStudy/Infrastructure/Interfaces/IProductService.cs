using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.NewDomain.Entities;
using ShopStudy.NewDomain.FIlters;

namespace ShopStudy.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter productFilter);
        Product GetProductById(int id);
    }
}
