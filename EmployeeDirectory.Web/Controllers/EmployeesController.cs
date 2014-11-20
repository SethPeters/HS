using EmployeeDirectory.Data;
using EmployeeDirectory.Data.Entities;
using EmployeeDirectory.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDirectory.Web
{
    public class EmployeesController : Controller
    {
        public EmployeesController()
        {
            EmployeeRepository = new Repository<Employee>(db);
            OfficeRepository = new Repository<Office>(db);
        }

        public EmployeesController(IRepository<Employee> empRepository, Repository<Office> officeRepository)
        {
            EmployeeRepository = empRepository;
            OfficeRepository = officeRepository;
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        private IRepository<Employee> EmployeeRepository;
        private IRepository<Office> OfficeRepository;

        // GET: Employees
        public ActionResult Index(int? page)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(EmployeeRepository.Get().OrderBy(a => a.LastName).ThenBy(b => b.FirstName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmployeeRepository.GetByKey(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OfficeId = new SelectList(OfficeRepository.EntitySet, "OfficeId", "OfficeName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "EmployeeNo,FirstName,LastName,Title,OfficeId,VacationHours,ChangeDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OfficeId = new SelectList(OfficeRepository.EntitySet, "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmployeeRepository.GetByKey(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(OfficeRepository.EntitySet, "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "EmployeeNo,FirstName,LastName,Title,OfficeId,VacationHours,ChangeUser,ChangeDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OfficeId = new SelectList(OfficeRepository.EntitySet, "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = EmployeeRepository.GetByKey(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = EmployeeRepository.GetByKey(id);
            EmployeeRepository.Delete(employee);
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