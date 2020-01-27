using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Models;

namespace ShopStudy.Infrastructure.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Commit();
        void AddNew(T model);
        void Delete(int id);
    }
}
