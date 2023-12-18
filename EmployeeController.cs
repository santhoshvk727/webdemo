using Microsoft.AspNetCore.Mvc;
using Webdemo.Models;
using System.Linq;

namespace Webdemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees);
        }

        //HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Success", employee);
        }

        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault();

            return View(employee);

        }
        [HttpPost]

        public IActionResult Update(Employee employee, string empname)
        {
            Repository.AllEmployees.Where(e => empname == e.name).FirstOrDefault().age = employee.age;
            Repository.AllEmployees.Where(e => empname == e.name).FirstOrDefault().salary = employee.salary;
            Repository.AllEmployees.Where(e => empname == e.name).FirstOrDefault().department = employee.department;
            Repository.AllEmployees.Where(e => empname == e.name).FirstOrDefault().gender = employee.gender;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }

    }
}