using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopStudy.Models
{
    public class CoffeeShopViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductCost { get; set; }
        public int ProductSale { get; set; }
        public int ProductRating { get; set; }
        public string Storage { get; set; }

        public CoffeeShopViewModel()
        {
                
        }
    }
}
