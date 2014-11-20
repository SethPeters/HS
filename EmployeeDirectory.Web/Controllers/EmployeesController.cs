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

        [HttpPost]
        public ActionResult Index(string employeeSearch, string employeeNo, int? page)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(employeeNo))
            {
                int empNo;
                int.TryParse(employeeNo, out empNo);
                return View(EmployeeRepository.Get().Where(x => x.EmployeeNo == empNo).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(EmployeeRepository.Get().Where(x => x.Name.Contains(employeeSearch)).OrderBy(a => a.LastName).ThenBy(b => b.FirstName).ToPagedList(pageNumber, pageSize));            
            }

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
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee = EmployeeRepository.Add(employee);
                return RedirectToAction("Details", "Employees", new { id = employee.EmployeeNo });
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
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee = EmployeeRepository.Update(employee);
                return RedirectToAction("Details", "Employees", new {id = employee.EmployeeNo});
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
            return RedirectToAction("Index");
        }

        public JsonResult AutocompleteSearch(string term)
        {
            var suggestions = EmployeeRepository.Get().ToList().Where(x => x.Name.ToLower().Contains(term.ToLower()));
            return Json(suggestions, JsonRequestBehavior.AllowGet);
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