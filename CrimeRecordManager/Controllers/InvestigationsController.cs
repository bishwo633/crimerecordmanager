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
    public class InvestigationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Investigations
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var investigations = db.Investigations.Include(i => i.Employee);
            return View(investigations.ToList());
        }

        // GET: Investigations/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigation investigation = db.Investigations.Find(id);
            if (investigation == null)
            {
                return HttpNotFound();
            }
            return View(investigation);
        }

        // GET: Investigations/Create
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName");
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvestigationDetails,InvestigationStartDate,InvestigationEndDate,EmployeeId")] Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                db.Investigations.Add(investigation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", investigation.EmployeeId);
            return View(investigation);
        }

        // GET: Investigations/Edit/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigation investigation = db.Investigations.Find(id);
            if (investigation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", investigation.EmployeeId);
            return View(investigation);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvestigationDetails,InvestigationStartDate,InvestigationEndDate,EmployeeId")] Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investigation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", investigation.EmployeeId);
            return View(investigation);
        }

        // GET: Investigations/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigation investigation = db.Investigations.Find(id);
            if (investigation == null)
            {
                return HttpNotFound();
            }
            return View(investigation);
        }

        // POST: Investigations/Delete/5
        [Authorize(Roles = "Admin,Officer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investigation investigation = db.Investigations.Find(id);
            db.Investigations.Remove(investigation);
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
