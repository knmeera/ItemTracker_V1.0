using ClassDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassDemo.Context;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    public class RegistrationController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "Role");
            Registration reg = new Registration();
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration reg)
        {
            int user = db.Registrations.Where(m => m.UserName == reg.UserName).Count();
            int email = db.Registrations.Where(m => m.EmailId == reg.EmailId).Count();
            if (ModelState.IsValid)
            {
                if (user != 1 && email != 1)
                {
                    db.Registrations.Add(reg);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                if(user ==1)
                {
                    ViewBag.status = "username already exists";
                }
                if(email ==1)
                {
                    ViewBag.status = "email Id already exists";
                }
            }           
            return View();
        }
        public ActionResult Login()
        {
            Registration reg = new Registration();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration reg)
        {

            if (reg.UserName!="" && reg.UserName!= null && reg.Password!="" && reg.Password!=null)
            {
                int sucess = db.Registrations.Where(m => m.UserName == reg.UserName && m.Password == reg.Password).Count();
                int count = db.Registrations.Where(m => m.UserName == reg.UserName).Count();

                if (sucess != 1)
                {
                    if (count == 0)
                    {
                        ViewBag.Login = "User Does Not Exist";
                    }
                    else if (count == 1)
                    {
                        ViewBag.Password = "Password is Incorect";
                    }
                }
                if (sucess == 1)
                {
                    var user = reg.UserName;
                    ViewBag.username = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }
        public ActionResult Details(string id)
        {
            var det = db.Registrations.Find(id);
            return View(det);
        }
        public ActionResult ChangePassword(Registration reg)
        {
            Registration details = db.Registrations.Find(reg.UserName);
            db.Entry(details).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Registration");
        }
    }
}