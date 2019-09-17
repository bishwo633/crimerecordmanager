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
    public class PoliceStationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PoliceStations
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var policeStations = db.PoliceStations.Include(p => p.ComplaintRegistration);
            return View(policeStations.ToList());
        }

        // GET: PoliceStations/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policeStation = db.PoliceStations.Find(id);
            if (policeStation == null)
            {
                return HttpNotFound();
            }
            return View(policeStation);
        }

        // GET: PoliceStations/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ComplaintRegistrationId = new SelectList(db.ComplaintRegistrations, "Id", "ComplainBy");
            return View();
        }

        // POST: PoliceStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PoliceStationName,StartingDate,Address,Phone,Email,Fax,ComplaintRegistrationId")] PoliceStation policeStation)
        {
            if (ModelState.IsValid)
            {
                db.PoliceStations.Add(policeStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplaintRegistrationId = new SelectList(db.ComplaintRegistrations, "Id", "ComplainBy", policeStation.ComplaintRegistrationId);
            return View(policeStation);
        }

        // GET: PoliceStations/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policeStation = db.PoliceStations.Find(id);
            if (policeStation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplaintRegistrationId = new SelectList(db.ComplaintRegistrations, "Id", "ComplainBy", policeStation.ComplaintRegistrationId);
            return View(policeStation);
        }

        // POST: PoliceStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PoliceStationName,StartingDate,Address,Phone,Email,Fax,ComplaintRegistrationId")] PoliceStation policeStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplaintRegistrationId = new SelectList(db.ComplaintRegistrations, "Id", "ComplainBy", policeStation.ComplaintRegistrationId);
            return View(policeStation);
        }

        // GET: PoliceStations/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policeStation = db.PoliceStations.Find(id);
            if (policeStation == null)
            {
                return HttpNotFound();
            }
            return View(policeStation);
        }

        // POST: PoliceStations/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceStation policeStation = db.PoliceStations.Find(id);
            db.PoliceStations.Remove(policeStation);
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
