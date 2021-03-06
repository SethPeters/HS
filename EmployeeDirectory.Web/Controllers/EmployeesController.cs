﻿using EmployeeDirectory.Data;
using EmployeeDirectory.Data.Entities;
using EmployeeDirectory.Data.Service;
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
        //public EmployeesController()
        //{
        //    EmployeeRepository = new Repository<Employee>(db);
        //    OfficeRepository = new Repository<Office>(db);
        //}

        public EmployeesController(IDirectoryService ds)
        {
            DirectoryService = ds;
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        private IDirectoryService DirectoryService;

        // GET: Employees
        public ActionResult Index(int? page)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(DirectoryService.GetEmployeesByFilter().ToPagedList(pageNumber, pageSize));
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
                return View(DirectoryService.GetEmployeesByFilter(x => x.EmployeeNo == empNo).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(DirectoryService.GetEmployeesByFilter(x => x.Name.Contains(employeeSearch)).ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = DirectoryService.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "HR")]
        public ActionResult Create()
        {
            ViewBag.OfficeId = new SelectList(DirectoryService.GetOffices(), "OfficeId", "OfficeName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "HR")]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee = DirectoryService.AddEmployee(employee);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details", "Employees", new { id = employee.EmployeeNo });
            }

            ViewBag.OfficeId = new SelectList(DirectoryService.GetOffices(), "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "HR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = DirectoryService.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(DirectoryService.GetOffices(), "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "HR")]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee = DirectoryService.UpdateEmployee(employee);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details", "Employees", new { id = employee.EmployeeNo });
            }
            ViewBag.OfficeId = new SelectList(DirectoryService.GetOffices(), "OfficeId", "OfficeName", employee.OfficeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "HR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = DirectoryService.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "HR")]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectoryService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public JsonResult AutocompleteSearch(string term)
        {
            var suggestions = DirectoryService.GetEmployeesByFilter(x => x.Name.ToLower().Contains(term.ToLower()));
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