using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassDemo.Context;
using ClassDemo.Models;
using System.Data.Entity;

namespace ClassDemo.Controllers
{
    public class ItemStatusController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemStatusView()
        {
            ItemStatus stat = new ItemStatus();
            return View(db.ItemStatuses.ToList());
        }
        [HttpPost]
        public ActionResult ItemStatusView(ItemStatus stat)
        {
            if(ModelState.IsValid)
            {
                db.ItemStatuses.Add(stat);
                db.SaveChanges();
                return RedirectToAction("ItemStatusView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            ItemStatus stat = db.ItemStatuses.Find(id);
            db.ItemStatuses.Remove(stat);
            db.SaveChanges();
            return RedirectToAction("ItemStatusView");
        }
        public ActionResult Edit(int id)
        {
            ItemStatus stat = db.ItemStatuses.Find(id);
            return View(stat);
        }
        [HttpPost]
        public ActionResult Edit(ItemStatus stat)
        {
            db.Entry(stat).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ItemStatusView");
        }
    }
}