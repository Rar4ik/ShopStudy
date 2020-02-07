using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Implementation;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;

namespace ShopStudy.Controllers
{
    [Route("Employees")]
    [Authorize]
    public class WorkerController : Controller
    {
        //Инициализация
        #region 
        private ICrud<WorkerViewModel> _employeesSercvice;
        public WorkerController(ICrud<WorkerViewModel> crud)
        {
            _employeesSercvice = crud;
        }
        #endregion
        
        [HttpGet]
        [Route("all")]
        public IActionResult Workers()
        {
            var worker = _employeesSercvice;
            return View(worker.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult WorkerDetails(int id)
        {
            var worker = _employeesSercvice.GetById(id);
            if (worker == null)
                return NotFound();
            return View(worker);
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new WorkerViewModel());
            var viewModel = _employeesSercvice.GetById(id.Value);
            if (viewModel == null)
                return NotFound();
            return View(viewModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _employeesSercvice.Delete(id);
            return RedirectToAction(nameof(Workers));
        }
        [HttpPost]
        [Route("Edit/{id?}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(WorkerViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            if (model.Id > 0)
            {
                var dbItem = _employeesSercvice.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();
                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Sex = model.Sex;
                dbItem.Salary = model.Salary;
            }
            else
            {
                _employeesSercvice.AddNew(model);
            }
            _employeesSercvice.Commit();
            return RedirectToAction(nameof(Workers));
        }
    }
}
