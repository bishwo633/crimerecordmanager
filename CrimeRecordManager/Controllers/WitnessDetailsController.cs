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
    public class WitnessDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WitnessDetails
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Index()
        {
            return View(db.WitnessDetails.ToList());
        }

        // GET: WitnessDetails/Details/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WitnessDetails witnessDetails = db.WitnessDetails.Find(id);
            if (witnessDetails == null)
            {
                return HttpNotFound();
            }
            return View(witnessDetails);
        }

        // GET: WitnessDetails/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WitnessDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WitnessName,Age,Address,Phone,Gender,Email,RegistrationDate")] WitnessDetails witnessDetails)
        {
            if (ModelState.IsValid)
            {
                db.WitnessDetails.Add(witnessDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(witnessDetails);
        }

        // GET: WitnessDetails/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WitnessDetails witnessDetails = db.WitnessDetails.Find(id);
            if (witnessDetails == null)
            {
                return HttpNotFound();
            }
            return View(witnessDetails);
        }

        // POST: WitnessDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WitnessName,Age,Address,Phone,Gender,Email,RegistrationDate")] WitnessDetails witnessDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(witnessDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(witnessDetails);
        }

        // GET: WitnessDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WitnessDetails witnessDetails = db.WitnessDetails.Find(id);
            if (witnessDetails == null)
            {
                return HttpNotFound();
            }
            return View(witnessDetails);
        }

        // POST: WitnessDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WitnessDetails witnessDetails = db.WitnessDetails.Find(id);
            db.WitnessDetails.Remove(witnessDetails);
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
