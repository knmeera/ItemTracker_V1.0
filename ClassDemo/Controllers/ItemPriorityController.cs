using ClassDemo.Context;
using ClassDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassDemo.Controllers
{
    public class ItemPriorityController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemPriorityView()
        {
            ItemPriority prio = new ItemPriority();
            return View(db.ItemPriorities.ToList());
        }
        [HttpPost]
        public ActionResult ItemPriorityView(ItemPriority prio)
        {
            if (ModelState.IsValid)
            {
                db.ItemPriorities.Add(prio);
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ItemPriority prio = db.ItemPriorities.Find(id);
            return View(prio);
        }
        [HttpPost]
        public ActionResult Edit(ItemPriority prio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View(prio);
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                ItemPriority pri = db.ItemPriorities.Find(id);
                db.ItemPriorities.Remove(pri);
                db.SaveChanges();
                return RedirectToAction("ItemPriorityView");
            }
            return View();
        }
    }
}