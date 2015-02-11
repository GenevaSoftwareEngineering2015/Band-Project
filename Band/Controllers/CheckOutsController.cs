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
    public class CheckOutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instruments
        public ActionResult Index()
        {
            return View(db.Instruments.ToList());
        }

        public ActionResult Archive()
        {
            return View(db.Instruments.ToList());
        }

        // GET: Instruments/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            CheckOuts instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // GET: Instruments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstrumentName,Name,Date,Comment,ID,MaintenanceNeeded")] CheckOuts instrument)
        {
            instrument.IsCheckedOut = true;
            if (ModelState.IsValid)
            {
                db.Instruments.Add(instrument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrument);
        }

        // GET: Instruments/Edit/5
        public ActionResult Edit(int id)
        {
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            CheckOuts instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "InstrumentName,Name,Date,Comment,MaintenanceNeeded")] CheckOuts instrument)
        {
            CheckOuts inst2 = db.Instruments.Find(id);
            inst2.InstrumentName = instrument.InstrumentName;
            inst2.Name = instrument.Name; 
            inst2.Date = instrument.Date;
            inst2.Comment = instrument.Comment;
            if (ModelState.IsValid)
            {
                db.Entry(inst2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrument);

            //if (ModelState.IsValid)
            //{
            //    db.Entry(instrument).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(instrument);
        }

        // GET: Instruments/Delete/5
        public ActionResult CheckIn(int id)
        {
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            CheckOuts instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("CheckIn")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, [Bind(Include = "DateIn,CommentIn,MaintenanceNeeded")] CheckOuts instrument)
        {
            CheckOuts inst2 = db.Instruments.Find(id);
            inst2.DateIn = instrument.DateIn;
            inst2.CommentIn = instrument.CommentIn;
            inst2.IsCheckedOut = false;
            if (ModelState.IsValid)
            {
                db.Entry(inst2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrument);
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
