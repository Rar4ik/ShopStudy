using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Data;
using ShopStudy.Models;

namespace ShopStudy.Controllers
{
    public class WorkerController : Controller
    {
        private List<WorkerModel> GetWorkers()
        {
            WorkerData workerData = new WorkerData();
            var gettingWorkers = workerData.SendWorkersData();
            return gettingWorkers;
        }
        
        public IActionResult Workers()
        {
            return View(GetWorkers());
        }

        public IActionResult WorkerDetails(int id)
        {
            var worker = GetWorkers().FirstOrDefault(x => x.Id == id);
            if (worker == null)
                return NotFound();
            return View(worker);
        }
    }
}
