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
    public class VictimDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VictimDetails
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Index()
        {
            return View(db.VictimDetails.ToList());
        }

        // GET: VictimDetails/Details/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimDetails victimDetails = db.VictimDetails.Find(id);
            if (victimDetails == null)
            {
                return HttpNotFound();
            }
            return View(victimDetails);
        }

        // GET: VictimDetails/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VictimName,Age,Address,Country,Phone,Email,Gender,RegistrationDate,OthersDetails")] VictimDetails victimDetails)
        {
            if (ModelState.IsValid)
            {
                db.VictimDetails.Add(victimDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimDetails);
        }

        // GET: VictimDetails/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimDetails victimDetails = db.VictimDetails.Find(id);
            if (victimDetails == null)
            {
                return HttpNotFound();
            }
            return View(victimDetails);
        }

        // POST: VictimDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VictimName,Age,Address,Country,Phone,Email,Gender,RegistrationDate,OthersDetails")] VictimDetails victimDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimDetails);
        }

        // GET: VictimDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimDetails victimDetails = db.VictimDetails.Find(id);
            if (victimDetails == null)
            {
                return HttpNotFound();
            }
            return View(victimDetails);
        }

        // POST: VictimDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimDetails victimDetails = db.VictimDetails.Find(id);
            db.VictimDetails.Remove(victimDetails);
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
