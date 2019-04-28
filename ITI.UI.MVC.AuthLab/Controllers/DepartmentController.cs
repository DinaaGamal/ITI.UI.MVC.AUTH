using ITI.UI.MVC.AuthLab.Models;
using ITI.UI.MVC.AuthLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.AuthLab.Controllers
{
       [Authorize(Roles ="Admin,Manager")]
        public class DepartmentController : Controller
        {

        ApplicationDbContext context = new ApplicationDbContext();

            // GET: Department
            public ActionResult Index()
            {
                return View(context.Departments.ToList());
            }
        [Authorize(Roles ="Admin")]
            public ActionResult Add()
            {
                ViewBag.Action = "Add";

                return View("Add");
            }
            [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult Add(Department department)
            {
                if (ModelState.IsValid)
                {
                    context.Departments.Add(department);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Add", department);
            }
        }

    }
