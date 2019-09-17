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
    public class ChargeSheetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChargeSheets
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var chargeSheets = db.ChargeSheets.Include(c => c.Fir);
            return View(chargeSheets.ToList());
        }

        // GET: ChargeSheets/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeSheet chargeSheet = db.ChargeSheets.Find(id);
            if (chargeSheet == null)
            {
                return HttpNotFound();
            }
            return View(chargeSheet);
        }

        // GET: ChargeSheets/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            ViewBag.FirId = new SelectList(db.Firs, "Id", "LocationDetails");
            return View();
        }

        // POST: ChargeSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChargeSheetDetails,ChargeSheetIssueDate,ChargeSheetBy,FirId")] ChargeSheet chargeSheet)
        {
            if (ModelState.IsValid)
            {
                db.ChargeSheets.Add(chargeSheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirId = new SelectList(db.Firs, "Id", "LocationDetails", chargeSheet.FirId);
            return View(chargeSheet);
        }

        // GET: ChargeSheets/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeSheet chargeSheet = db.ChargeSheets.Find(id);
            if (chargeSheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirId = new SelectList(db.Firs, "Id", "LocationDetails", chargeSheet.FirId);
            return View(chargeSheet);
        }

        // POST: ChargeSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChargeSheetDetails,ChargeSheetIssueDate,ChargeSheetBy,FirId")] ChargeSheet chargeSheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chargeSheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirId = new SelectList(db.Firs, "Id", "LocationDetails", chargeSheet.FirId);
            return View(chargeSheet);
        }

        // GET: ChargeSheets/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeSheet chargeSheet = db.ChargeSheets.Find(id);
            if (chargeSheet == null)
            {
                return HttpNotFound();
            }
            return View(chargeSheet);
        }

        // POST: ChargeSheets/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChargeSheet chargeSheet = db.ChargeSheets.Find(id);
            db.ChargeSheets.Remove(chargeSheet);
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
