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
    /// <summary>
    /// Department Controller 
    /// </summary>
    public class DepartmentController : Controller
    {
        /// <summary>
        /// GenericUoW and RepositoryContext Instances
        /// </summary>
        private readonly GenericUoW UoW = null;
        private readonly RepositoryContext _context = null;

        /// <summary>
        /// DepartmentController constructor where UoW instance sets
        /// </summary>
        public DepartmentController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW = new GenericUoW(this._context);
        }

        /// <summary>
        /// Department/Index views corresponding action
        /// </summary>
        /// <returns>Index view with Department List Model</returns>
        public ActionResult Index()
        {
            return View(UoW.Repository<Department>().GetAll(includes: "Faculty").OrderBy(o => o.Faculty.Name).ToList());
        }

        /// <summary>
        /// GET: Department/Details views corresponding action
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns>Details view with DepartmentCourse List that has given id</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(UoW.Repository<DepartmentCourse>().GetAll(x => x.Department_ID == id, includes: new string[] { "Term", "Course" }).OrderBy(o => o.Term.ID).ToList());
        }

        /// <summary>
        /// GET: Department/Create views corresponding action
        /// </summary>
        /// <returns>Empty form view to Create new Department</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Department/Create Insert operation
        /// </summary>
        /// <param name="Department">Department to insert</param>
        /// <returns>View with inserted Department model</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Faculty,Description")] Department Department)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Department>().Add(Department);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Department);
        }

        /// <summary>
        /// GET: Department/Edit views corresponding action
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department Department = UoW.Repository<Department>().Get(x => x.ID == id);
            if (Department == null)
            {
                return HttpNotFound();
            }
            return View(Department);
        }

        /// <summary>
        /// POST: Department/Create Update operation
        /// </summary>
        /// <param name="Department">Department to edit</param>
        /// <returns>Corresponding view with its new value</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Faculty,Description")] Department Department)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Department>().Attach(Department);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Department);
        }

        /// <summary>
        /// GET: Department/Delete views corresponding action
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department Department = UoW.Repository<Department>().Get(x => x.ID == id);
            if (Department == null)
            {
                return HttpNotFound();
            }
            return View(Department);
        }

        /// <summary>
        /// POST: Department/Delete Delete operation
        /// </summary>        
        /// <param name="id">Department id</param>
        /// <returns>Redirected to Department/Index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department Department = UoW.Repository<Department>().Get(x => x.ID == id);
            UoW.Repository<Department>().Delete(Department);
            UoW.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Controller Dispose Operation
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UoW.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
