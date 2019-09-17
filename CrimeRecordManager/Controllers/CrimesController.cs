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
    public class CrimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Crimes
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            return View(db.Crimes.ToList());
        }

        // GET: Crimes/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crime crime = db.Crimes.Find(id);
            if (crime == null)
            {
                return HttpNotFound();
            }
            return View(crime);
        }

        // GET: Crimes/Create
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer,Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CrimesName,Description,Location")] Crime crime)
        {
            if (ModelState.IsValid)
            {
                db.Crimes.Add(crime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crime);
        }

        // GET: Crimes/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crime crime = db.Crimes.Find(id);
            if (crime == null)
            {
                return HttpNotFound();
            }
            return View(crime);
        }

        // POST: Crimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CrimesName,Description,Location")] Crime crime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crime);
        }

        // GET: Crimes/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crime crime = db.Crimes.Find(id);
            if (crime == null)
            {
                return HttpNotFound();
            }
            return View(crime);
        }

        // POST: Crimes/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crime crime = db.Crimes.Find(id);
            db.Crimes.Remove(crime);
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
