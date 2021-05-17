using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Azure.Models;
using EmployeeManager.Azure.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    }
}
