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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Designation).Include(e => e.PoliceStation);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        [Authorize(Roles = "Admin,Officer,Writer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName");
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeName,Age,Gender,Address,Phone,Email,DateofBirth,JoiningDate,DepartmentId,DesignationId,PoliceStationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.DateofBirth.Year != DateTime.Now.AddYears(employee.Age * -1).Year)
                {
                    ViewBag.FlashMessage = "Mismatch value for Date of Birth and Age";
                    ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
                    ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
                    return View(employee);
                }

                if (employee.DateofBirth >= employee.JoiningDate)
                {
                    ViewBag.FlashMessage = "Mismatch value for Date of Birth and Joining Date";
                    ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
                    ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
                    return View(employee);
                }

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", employee.PoliceStationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", employee.PoliceStationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeName,Age,Gender,Address,Phone,Email,DateofBirth,JoiningDate,DepartmentId,DesignationId,PoliceStationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.DateofBirth.Year != DateTime.Now.AddYears(employee.Age * -1).Year)
                {
                    ViewBag.FlashMessage = "Mismatch value for Date of Birth and Age";
                    ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
                    ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
                    return View(employee);
                }

                if (employee.DateofBirth >= employee.JoiningDate)
                {
                    ViewBag.FlashMessage = "Mismatch value for Date of Birth and Joining Date";
                    ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
                    ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
                    return View(employee);
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", employee.PoliceStationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
