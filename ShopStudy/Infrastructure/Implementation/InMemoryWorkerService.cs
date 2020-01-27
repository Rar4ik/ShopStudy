using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;

namespace ShopStudy.Infrastructure.Implementation
{
    public class InMemoryWorkerService:ICrud<WorkerViewModel>
    {
        private readonly WorkerData _workersData = new WorkerData();
        private readonly List<WorkerViewModel> _workersModels;

        public InMemoryWorkerService()
        {
            _workersModels = _workersData.SendWorkersData();
        }
        public IEnumerable<WorkerViewModel> GetAll()
        {
            return _workersModels;
        }

        public WorkerViewModel GetById(int id)
        {
            return _workersModels.FirstOrDefault(e => e.Id == id);
        }

        public void Commit()
        {
            //wait for it
        }

        public void AddNew(WorkerViewModel model)
        {
            WorkerViewModel workerLocal = model;
            if (_workersModels.Count == 0)
            {
                _workersModels.Insert(0, workerLocal);
            }
            else
            {
                workerLocal.Id = _workersModels.Max(e => e.Id) + 1;
                _workersModels.Add(workerLocal);
            }

        }

        public void Delete(int id)
        {
            WorkerViewModel employee = GetById(id);
            if (employee != null)
                _workersModels.Remove(employee);
        }
    }
}
