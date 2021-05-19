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
    }    
}
