using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Band.Models;

namespace Band.Controllers
{
    public class MaintenanceHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MaintenanceHistory/
        public ActionResult Index()
        {
            var maintenancehistories = db.MaintenanceHistories.Include(m => m.InstID);
            return View(maintenancehistories.ToList());
        }

        // GET: /MaintenanceHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceHistory maintenancehistory = db.MaintenanceHistories.Find(id);
            if (maintenancehistory == null)
            {
                return HttpNotFound();
            }
            return View(maintenancehistory);
        }

        // GET: /MaintenanceHistory/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Instruments, "ID", "ReadableID");
            return View();
        }

        // POST: /MaintenanceHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Comment,Price,Date")] MaintenanceHistory maintenancehistory)
        {
            if (ModelState.IsValid)
            {
                db.MaintenanceHistories.Add(maintenancehistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Instruments, "ID", "ReadableID", maintenancehistory.ID);
            return View(maintenancehistory);
        }

        // GET: /MaintenanceHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceHistory maintenancehistory = db.MaintenanceHistories.Find(id);
            if (maintenancehistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Instruments, "ID", "ReadableID", maintenancehistory.ID);
            return View(maintenancehistory);
        }

        // POST: /MaintenanceHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Comment,Price,Date")] MaintenanceHistory maintenancehistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenancehistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Instruments, "ID", "ReadableID", maintenancehistory.ID);
            return View(maintenancehistory);
        }

        // GET: /MaintenanceHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceHistory maintenancehistory = db.MaintenanceHistories.Find(id);
            if (maintenancehistory == null)
            {
                return HttpNotFound();
            }
            return View(maintenancehistory);
        }

        // POST: /MaintenanceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceHistory maintenancehistory = db.MaintenanceHistories.Find(id);
            db.MaintenanceHistories.Remove(maintenancehistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
