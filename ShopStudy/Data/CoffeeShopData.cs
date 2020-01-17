﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Models;

namespace ShopStudy.Data
{
    public class CoffeeShopData
    {
        private readonly List<CoffeeShopModel> _coffeeShop = new List<CoffeeShopModel>();

        public CoffeeShopData()
        {
            _coffeeShop.Add(
                new CoffeeShopModel
                {
                    Id = 1,
                    ProductCategory = "Arabica",
                    ProductCost = 1000,
                    ProductName = "Lavazza",
                    ProductRating = 4,
                    ProductSale = 5,
                    Storage = "Himki"
                });
            _coffeeShop.Add(
                new CoffeeShopModel
                {
                    Id = 2,
                    ProductCategory = "Robusta",
                    ProductCost = 2000,
                    ProductName = "Carraro",
                    ProductRating = 5,
                    ProductSale = 2,
                    Storage = "Schelkovo"
                });
            _coffeeShop.Add(
                new CoffeeShopModel
                {
                    Id = 3,
                    ProductCategory = "Arabica",
                    ProductCost = 1050,
                    ProductName = "Jardin",
                    ProductRating = 3,
                    ProductSale = 10,
                    Storage = "Himki"
                });

        }

        public List<CoffeeShopModel> SendCoffeeShopData()
        {
            return _coffeeShop;
        }
    }
}
