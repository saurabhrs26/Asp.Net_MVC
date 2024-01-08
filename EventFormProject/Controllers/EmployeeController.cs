using EventFormProject.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventFormProject.Models;

namespace EventFormProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDal employeeDal;
        public EmployeeController()
        {

        }
        public EmployeeController(EmployeeDal dal)
        {
            employeeDal = dal;
        }

        

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Welcome to the Employee List";
            ViewBag.PageSubTitle = "Core Development Team of India!";
            return View(employeeDal.GetAllEmployee());
        }

        public ActionResult Details(int empId)
        {
            ViewBag.PageTitle = "Welcome to the Employee List";
            ViewBag.PageSubTitle = "Core Development team of India";
            return View(employeeDal.GetEmployeeById(empId));
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee) 
        { 
           if(ModelState.IsValid)
            {
                employee.EmployeeAvtar = "~/Images/noimage.png";
                int result=employeeDal.InsertEmployee(employee);
                if(result>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();  
                }
            }
            return View();
        }
    }
}