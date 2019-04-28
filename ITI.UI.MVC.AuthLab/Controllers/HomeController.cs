using ITI.UI.MVC.AuthLab.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.AuthLab.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        ApplicationRoleManager roleManager;
        ApplicationUserManager userManager;

        public ApplicationDbContext Context
        {
            get
            {
                return context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }

        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }

     
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }

          
        }

        public ActionResult Index()
        {
            IdentityRole admin = new IdentityRole("Admin");
            IdentityRole manager = new IdentityRole("Manager");
            IdentityRole empolyee = new IdentityRole("Empolyee");

            RoleManager.Create(admin);
            RoleManager.Create(manager);
            RoleManager.Create(empolyee);

            ApplicationUser userAdmin = UserManager.Users.FirstOrDefault(u => u.Email.StartsWith("admin"));
            ApplicationUser userManager = UserManager.Users.FirstOrDefault(u => u.Email.StartsWith("manager"));
            ApplicationUser empUser = UserManager.Users.FirstOrDefault(u => u.Email.StartsWith("empolyee"));

            //userManager.AddToRole(adminUser.Id, admin.Name);
            //userManager.AddToRole(managerUser.Id, manager.Name);

            UserManager.AddToRole(userAdmin.Id, admin.Name);
            UserManager.AddToRole(userManager.Id, manager.Name);
            UserManager.AddToRole(empUser.Id, empolyee.Name);




            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}