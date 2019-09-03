using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepositoryUoW.Data;
using GenericRepositoryUoW.Models;

namespace GenericRepositoryUoW.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly GenericUoW UoW2 = null;
        private readonly RepositoryContext _context = null;

        public DepartmentController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW2 = new GenericUoW(this._context);
        }
        // GET: Department
        public ActionResult Index()
        {
            return View(UoW2.Repository<Department>().GetAll(includes: "Faculty").OrderBy(o => o.Faculty.Name).ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(UoW2.Repository<DepartmentCourse>().GetAll(x => x.Department_ID == id, includes: new string[] { "Term", "Course" }).OrderBy(o => o.Term.ID).ToList());
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Faculty,Description")] Department Department)
        {
            if (ModelState.IsValid)
            {
                UoW2.Repository<Department>().Add(Department);
                UoW2.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department Department = UoW2.Repository<Department>().Get(x => x.ID == id);
            if (Department == null)
            {
                return HttpNotFound();
            }
            return View(Department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Faculty,Description")] Department Department)
        {
            if (ModelState.IsValid)
            {
                UoW2.Repository<Department>().Attach(Department);
                UoW2.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department Department = UoW2.Repository<Department>().Get(x => x.ID == id);
            if (Department == null)
            {
                return HttpNotFound();
            }
            return View(Department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department Department = UoW2.Repository<Department>().Get(x => x.ID == id);
            UoW2.Repository<Department>().Delete(Department);
            UoW2.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UoW2.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
