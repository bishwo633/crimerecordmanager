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
    public class CrimeDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CrimeDetails
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var crimeDetails = db.CrimeDetails.Include(c => c.Crime);
            return View(crimeDetails.ToList());
        }

        // GET: CrimeDetails/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeDetail crimeDetail = db.CrimeDetails.Find(id);
            if (crimeDetail == null)
            {
                return HttpNotFound();
            }
            return View(crimeDetail);
        }

        // GET: CrimeDetails/Create
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Create()
        {
            ViewBag.CrimeId = new SelectList(db.Crimes, "Id", "CrimesName");
            return View();
        }

        // POST: CrimeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer,Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CrimeType,Description,CrimeId")] CrimeDetail crimeDetail)
        {
            if (ModelState.IsValid)
            {
                db.CrimeDetails.Add(crimeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CrimeId = new SelectList(db.Crimes, "Id", "CrimesName", crimeDetail.CrimeId);
            return View(crimeDetail);
        }

        // GET: CrimeDetails/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeDetail crimeDetail = db.CrimeDetails.Find(id);
            if (crimeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CrimeId = new SelectList(db.Crimes, "Id", "CrimesName", crimeDetail.CrimeId);
            return View(crimeDetail);
        }

        // POST: CrimeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CrimeType,Description,CrimeId")] CrimeDetail crimeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crimeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CrimeId = new SelectList(db.Crimes, "Id", "CrimesName", crimeDetail.CrimeId);
            return View(crimeDetail);
        }

        // GET: CrimeDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeDetail crimeDetail = db.CrimeDetails.Find(id);
            if (crimeDetail == null)
            {
                return HttpNotFound();
            }
            return View(crimeDetail);
        }

        // POST: CrimeDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CrimeDetail crimeDetail = db.CrimeDetails.Find(id);
            db.CrimeDetails.Remove(crimeDetail);
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
