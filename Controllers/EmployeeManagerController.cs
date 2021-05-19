using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Azure.Models;
using EmployeeManager.Azure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Azure.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeManagerController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IActionResult List()
        {
            List<Employee> model = employeeRepository.SelectAll();
            return View(model);
        }

        private void FillCountries()
        {
            List<string> countriesList = employeeRepository.SelectCountries();

            List<SelectListItem> countries = (from c in countriesList
                                              orderby c ascending
                                              select new SelectListItem()
                                              {
                                                  Text = c,
                                                  Value = c
                                              }).ToList();

            ViewBag.Countries = countries;
        }

        [HttpGet]
        public IActionResult Insert()
        {
            FillCountries();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Employee model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                employeeRepository.Insert(model);
                ViewBag.Message = "Employee Inserted Successfully";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            FillCountries();
            Employee model = employeeRepository.SelectByID(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                employeeRepository.Update(model);
                ViewBag.Message = "Employee Updated Successfully";
            }

            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Employee model = employeeRepository.SelectByID(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            // Redirecting to new page, cannot use viewbag, use tempData
            TempData["Message"] = "Employee Deleted Successfully";
            return RedirectToAction("List");
        }
    }    
}
