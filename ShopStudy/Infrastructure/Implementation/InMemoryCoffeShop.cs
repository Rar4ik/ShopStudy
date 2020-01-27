using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;

namespace ShopStudy.Infrastructure.Implementation
{
    public class InMemoryCoffeeShop : ICrud<CoffeeShopViewModel>
    {
        private readonly CoffeeShopData _coffeData = new CoffeeShopData();
        private readonly List<CoffeeShopViewModel> _coffeModels;

        public InMemoryCoffeeShop()
        {
            _coffeModels = _coffeData.SendCoffeeShopData();
        }

        public IEnumerable<CoffeeShopViewModel> GetAll()
        {
            return _coffeModels;
        }

        public CoffeeShopViewModel GetById(int id)
        {
            return _coffeModels.FirstOrDefault(e => e.Id == id);
        }

        public void Commit()
        {
            //wait for it
        }

        public void AddNew(CoffeeShopViewModel model)
        {
            CoffeeShopViewModel workerLocal = model;
            if (_coffeModels.Count == 0)
            {
                _coffeModels.Insert(0, workerLocal);
            }
            else
            {
                workerLocal.Id = _coffeModels.Max(e => e.Id) + 1;
                _coffeModels.Add(workerLocal);
            }
        }

        public void Delete(int id)
        {
            CoffeeShopViewModel employee = GetById(id);
            if (employee != null)
                _coffeModels.Remove(employee);
        }
    }
}
