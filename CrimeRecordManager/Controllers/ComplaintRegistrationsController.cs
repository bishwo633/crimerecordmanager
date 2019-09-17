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
    public class ComplaintRegistrationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ComplaintRegistrations
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var complaintRegistrations = db.ComplaintRegistrations.Include(c => c.AccusedDetail);
            return View(complaintRegistrations.ToList());
        }

        // GET: ComplaintRegistrations/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintRegistration complaintRegistration = db.ComplaintRegistrations.Find(id);
            if (complaintRegistration == null)
            {
                return HttpNotFound();
            }
            return View(complaintRegistration);
        }

        // GET: ComplaintRegistrations/Create
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Create()
        {
            ViewBag.AccusedDetailId = new SelectList(db.AccusedDetails, "Id", "AccusedName");
            return View();
        }

        // POST: ComplaintRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer,Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ComplainBy,CitizenshipNo,PhoneNumber,ComplainDate,ComplainDetails,AccusedDetailId")] ComplaintRegistration complaintRegistration)
        {
            if (ModelState.IsValid)
            {
                db.ComplaintRegistrations.Add(complaintRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccusedDetailId = new SelectList(db.AccusedDetails, "Id", "AccusedName", complaintRegistration.AccusedDetailId);
            return View(complaintRegistration);
        }

        // GET: ComplaintRegistrations/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintRegistration complaintRegistration = db.ComplaintRegistrations.Find(id);
            if (complaintRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccusedDetailId = new SelectList(db.AccusedDetails, "Id", "AccusedName", complaintRegistration.AccusedDetailId);
            return View(complaintRegistration);
        }

        // POST: ComplaintRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ComplainBy,CitizenshipNo,PhoneNumber,ComplainDate,ComplainDetails,AccusedDetailId")] ComplaintRegistration complaintRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccusedDetailId = new SelectList(db.AccusedDetails, "Id", "AccusedName", complaintRegistration.AccusedDetailId);
            return View(complaintRegistration);
        }

        // GET: ComplaintRegistrations/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintRegistration complaintRegistration = db.ComplaintRegistrations.Find(id);
            if (complaintRegistration == null)
            {
                return HttpNotFound();
            }
            return View(complaintRegistration);
        }

        // POST: ComplaintRegistrations/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplaintRegistration complaintRegistration = db.ComplaintRegistrations.Find(id);
            db.ComplaintRegistrations.Remove(complaintRegistration);
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
