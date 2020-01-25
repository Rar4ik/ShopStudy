using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Models;

namespace ShopStudy.Data
{
    public class WorkerData
    {
        private readonly List<WorkerViewModel> _workersModels = new List<WorkerViewModel>();

        public WorkerData()
        {
            _workersModels.Add(new WorkerViewModel {Id = 1, Age = 12, FirstName = "Howard", SurName = "Stalone", Sex = "Male", Salary = 120});
            _workersModels.Add(new WorkerViewModel {Id = 2, Age = 13, FirstName = "June", SurName = "Stalone", Sex = "Female", Salary = 100});
            _workersModels.Add(new WorkerViewModel {Id = 3, Age = 14, FirstName = "Ostin", SurName = "Stalone", Sex = "Male", Salary = 120});
            _workersModels.Add(new WorkerViewModel {Id = 4, Age = 15, FirstName = "Mark", SurName = "Stalone", Sex = "Male", Salary = 120});
        }

        public List<WorkerViewModel> SendWorkersData()
        {
            return _workersModels;
        }
    }
}
