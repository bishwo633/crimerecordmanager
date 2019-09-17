using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrimeRecordManager.Models;

namespace CrimeRecordManager.Controllers
{
    public class FirsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Firs
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Index()
        {
            var firs = db.Firs.Include(f => f.CrimeDetail);
            return View(firs.ToList());
        }

        // GET: Firs/Details/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fir fir = db.Firs.Find(id);
            if (fir == null)
            {
                return HttpNotFound();
            }
            return View(fir);
        }

        // GET: Firs/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType");
            return View();
        }

        // POST: Firs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationDetails,RegistrationDate,CrimeDate,CrimeDetailId")] Fir fir)
        {
            if (ModelState.IsValid)
            {
                db.Firs.Add(fir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", fir.CrimeDetailId);
            return View(fir);
        }

        // GET: Firs/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fir fir = db.Firs.Find(id);
            if (fir == null)
            {
                return HttpNotFound();
            }
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", fir.CrimeDetailId);
            return View(fir);
        }

        // POST: Firs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationDetails,RegistrationDate,CrimeDate,CrimeDetailId")] Fir fir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", fir.CrimeDetailId);
            return View(fir);
        }

        // GET: Firs/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fir fir = db.Firs.Find(id);
            if (fir == null)
            {
                return HttpNotFound();
            }
            return View(fir);
        }

        // POST: Firs/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fir fir = db.Firs.Find(id);
            db.Firs.Remove(fir);
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
