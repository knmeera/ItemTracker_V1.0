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
    public class ItemTypeController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult ItemTypeView()
        {
            ItemType it = new ItemType();
            return View(db.ItemTypes.ToList());
        }
        [HttpPost]
        public ActionResult ItemTypeView(ItemType it)
        {
            if(ModelState.IsValid)
            {
                db.ItemTypes.Add(it);
                db.SaveChanges();
                return RedirectToAction("ItemTypeView");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            ItemType it = db.ItemTypes.Find(id);
            db.ItemTypes.Remove(it);
            db.SaveChanges();
            return RedirectToAction("ItemTypeView");
        }
        public ActionResult Edit(int id)
        {
            ItemType it = db.ItemTypes.Find(id);
            return View(it);
        }
        [HttpPost]
        public ActionResult Edit(ItemType it)
        {
            db.Entry(it).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ItemTypeView");
        }
    }
}