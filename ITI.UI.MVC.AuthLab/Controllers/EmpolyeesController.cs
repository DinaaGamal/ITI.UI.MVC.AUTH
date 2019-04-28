using ITI.UI.MVC.AuthLab.Models.Entities;
using ITI.UI.MVC.AuthLab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ITI.UI.MVC.AuthLab.Models;
using System.Threading.Tasks;

namespace ITI.UI.MVC.AuthLab.Controllers
{
   [Authorize]
        // GET: Empolyees
        public class EmpolyeesController : Controller
        {
        static ApplicationDbContext context = new ApplicationDbContext();
            // GET: Empolyees

            public ActionResult Index()
            {
                ViewBag.Action = "Add";
                EmployeeViewModel empVM = new EmployeeViewModel();
                empVM.Departments = context.Departments.ToList();
                empVM.Employees = context.Empolyees.ToList();
                return View(empVM);
            }

            //here i open the page that send data
            [HttpGet]
        [Authorize(Roles = "Manager,Admin")]

        public ActionResult Add()
            {
                EmployeeViewModel empVm = new EmployeeViewModel();
                empVm.Departments = context.Departments.ToList();
                ViewBag.Action = "Add";
                return View("AddEdit", empVm);
            }
            [HttpPost]
            [Authorize(Roles ="Manager,Admin")]

            //herei post on it 
            public ActionResult Add(EmployeeViewModel empVM)
            {
                if (ModelState.IsValid)
                {
                    context.Empolyees.Add(empVM.Empolyee);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                EmployeeViewModel eVm = new EmployeeViewModel();
            eVm.Empolyee = empVM.Empolyee;
                eVm.Departments = context.Departments.ToList();
                return View("AddEdit", eVm);
            }


        public ActionResult Edit(int id)
            {

                Empolyee emp = context.Empolyees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    ViewBag.Action = "Edit";
                    EmployeeViewModel empVM = new EmployeeViewModel();
                    empVM.Empolyee = emp;
                    empVM.Departments = context.Departments.ToList();
                    return View("AddEdit", empVM);

                }
                return RedirectToAction("Index");
            }
        [Authorize(Roles = "Manager,Admin")]


        [HttpPost]
            public ActionResult Edit(Empolyee empolyee)
            {
                if (ModelState.IsValid)
                {
                    var prevEmp = context.Empolyees.FirstOrDefault(e => e.Id == empolyee.Id);

                    if (prevEmp != null)
                    {
                        prevEmp.Name = empolyee.Name;
                        prevEmp.Age = empolyee.Age;
                        prevEmp.Email = empolyee.Email;
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");

                }
                return View("AddEdit", empolyee);
            }

        [Authorize(Roles = "Manager,Admin")]

        public async Task<bool> Delete(int id)
            {
                Empolyee delEmp = context.Empolyees.FirstOrDefault(e => e.Id == id);
                if (delEmp != null)
                {
                    context.Empolyees.Remove(delEmp);
                    await context.SaveChangesAsync();

                    return true;
                }
                return false;

            }

            public ActionResult Show(int id)
            {
                Empolyee Emp = context.Empolyees.FirstOrDefault(e => e.Id == id);
                return View("Show", Emp);
            }
        }

    }
