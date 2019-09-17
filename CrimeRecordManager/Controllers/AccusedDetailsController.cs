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
    public class AccusedDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccusedDetails
        public ActionResult Index()
        {
            return View(db.AccusedDetails.ToList());
        }

        // GET: AccusedDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedDetail accusedDetail = db.AccusedDetails.Find(id);
            if (accusedDetail == null)
            {
                return HttpNotFound();
            }
            return View(accusedDetail);
        }

        // GET: AccusedDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccusedDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccusedName,OthersDetails")] AccusedDetail accusedDetail)
        {
            if (ModelState.IsValid)
            {
                db.AccusedDetails.Add(accusedDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accusedDetail);
        }

        // GET: AccusedDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedDetail accusedDetail = db.AccusedDetails.Find(id);
            if (accusedDetail == null)
            {
                return HttpNotFound();
            }
            return View(accusedDetail);
        }

        // POST: AccusedDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccusedName,OthersDetails")] AccusedDetail accusedDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accusedDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accusedDetail);
        }

        // GET: AccusedDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedDetail accusedDetail = db.AccusedDetails.Find(id);
            if (accusedDetail == null)
            {
                return HttpNotFound();
            }
            return View(accusedDetail);
        }

        // POST: AccusedDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccusedDetail accusedDetail = db.AccusedDetails.Find(id);
            db.AccusedDetails.Remove(accusedDetail);
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
