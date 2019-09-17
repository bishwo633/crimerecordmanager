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
    public class CriminalDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CriminalDetails
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Index()
        {
            var criminalDetails = db.CriminalDetails.Include(c => c.CrimeDetail).Include(c => c.PoliceStation);
            return View(criminalDetails.ToList());
        }

        // GET: CriminalDetails/Details/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalDetails criminalDetails = db.CriminalDetails.Find(id);
            if (criminalDetails == null)
            {
                return HttpNotFound();
            }
            return View(criminalDetails);
        }

        // GET: CriminalDetails/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType");
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName");
            return View();
        }

        // POST: CriminalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CriminalName,Age,Status,Phone,Email,Gender,OldRecord,PoliceStationId,CrimeDetailId")] CriminalDetails criminalDetails)
        {
            if (ModelState.IsValid)
            {
                db.CriminalDetails.Add(criminalDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", criminalDetails.CrimeDetailId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", criminalDetails.PoliceStationId);
            return View(criminalDetails);
        }

        // GET: CriminalDetails/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalDetails criminalDetails = db.CriminalDetails.Find(id);
            if (criminalDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", criminalDetails.CrimeDetailId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", criminalDetails.PoliceStationId);
            return View(criminalDetails);
        }

        // POST: CriminalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CriminalName,Age,Status,Phone,Email,Gender,OldRecord,PoliceStationId,CrimeDetailId")] CriminalDetails criminalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criminalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CrimeDetailId = new SelectList(db.CrimeDetails, "Id", "CrimeType", criminalDetails.CrimeDetailId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", criminalDetails.PoliceStationId);
            return View(criminalDetails);
        }

        // GET: CriminalDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalDetails criminalDetails = db.CriminalDetails.Find(id);
            if (criminalDetails == null)
            {
                return HttpNotFound();
            }
            return View(criminalDetails);
        }

        // POST: CriminalDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CriminalDetails criminalDetails = db.CriminalDetails.Find(id);
            db.CriminalDetails.Remove(criminalDetails);
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
