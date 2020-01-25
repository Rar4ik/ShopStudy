using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Models;

namespace ShopStudy.Infrastructure.Interfaces
{
    public interface ICrud
    {
        IEnumerable<object> GetAll();
        object GetById(int id);
        void Commit();
        void AddNew(object model);
        void Delete(int id);
    }
}
