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
    public class EvidenceDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EvidenceDetails
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var evidenceDetails = db.EvidenceDetails.Include(e => e.Investigation);
            return View(evidenceDetails.ToList());
        }

        // GET: EvidenceDetails/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceDetails evidenceDetails = db.EvidenceDetails.Find(id);
            if (evidenceDetails == null)
            {
                return HttpNotFound();
            }
            return View(evidenceDetails);
        }

        // GET: EvidenceDetails/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            ViewBag.InvestigationId = new SelectList(db.Investigations, "Id", "InvestigationDetails");
            return View();
        }

        // POST: EvidenceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EvidenceName,EvidenceType,EvidenceFindingDate,Description,InvestigationId")] EvidenceDetails evidenceDetails)
        {
            if (ModelState.IsValid)
            {
                db.EvidenceDetails.Add(evidenceDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvestigationId = new SelectList(db.Investigations, "Id", "InvestigationDetails", evidenceDetails.InvestigationId);
            return View(evidenceDetails);
        }

        // GET: EvidenceDetails/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceDetails evidenceDetails = db.EvidenceDetails.Find(id);
            if (evidenceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvestigationId = new SelectList(db.Investigations, "Id", "InvestigationDetails", evidenceDetails.InvestigationId);
            return View(evidenceDetails);
        }

        // POST: EvidenceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EvidenceName,EvidenceType,EvidenceFindingDate,Description,InvestigationId")] EvidenceDetails evidenceDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidenceDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvestigationId = new SelectList(db.Investigations, "Id", "InvestigationDetails", evidenceDetails.InvestigationId);
            return View(evidenceDetails);
        }

        // GET: EvidenceDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceDetails evidenceDetails = db.EvidenceDetails.Find(id);
            if (evidenceDetails == null)
            {
                return HttpNotFound();
            }
            return View(evidenceDetails);
        }

        // POST: EvidenceDetails/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EvidenceDetails evidenceDetails = db.EvidenceDetails.Find(id);
            db.EvidenceDetails.Remove(evidenceDetails);
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
