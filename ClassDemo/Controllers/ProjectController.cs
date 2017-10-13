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
    public class ProjectController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ProjectView()
        {
            Project pro = new Project();
            return View(db.projects.ToList());
        }
        [HttpPost]
        public ActionResult ProjectView(Project pro)
        {
            if (ModelState.IsValid)
            {
                db.projects.Add(pro);
                db.SaveChanges();
                return RedirectToAction("ProjectView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Project pro = db.projects.Find(id);
            db.projects.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("ProjectView");
        }
        public ActionResult Edit(int id)
        {
            Project pro = db.projects.Find(id);
            
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Project pro)
        {
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProjectView");
        }
    }
}