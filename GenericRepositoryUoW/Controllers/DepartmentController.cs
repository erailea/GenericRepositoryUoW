using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepositoryUoW.Services;
using GenericRepositoryUoW.Data.Models;
using Ninject;
using GenericRepositoryUoW.Data.UoW;
using GenericRepositoryUoW.Services.Interfaces;

namespace GenericRepositoryUoW.Controllers
{
    /// <summary>
    /// Department Controller 
    /// </summary>
    public class DepartmentController : Controller
    {
        /// <summary>
        /// Needed service instances
        /// </summary>
        private readonly IDepartmentService departmentService;
        private readonly IDepartmentCourseService departmentCourseService;
        
        /// <summary>
        /// DepartmentController constructor where service instances set
        /// </summary>
        public DepartmentController(IDepartmentService departmentServiceParam,IDepartmentCourseService departmentCourseServiceParam)
        {
            this.departmentService = departmentServiceParam;
            this.departmentCourseService = departmentCourseServiceParam;
        }

        /// <summary>
        /// Department/Index views corresponding action
        /// </summary>
        /// <returns>Index view with Department List Model</returns>
        public ActionResult Index()
        {
            return View(departmentService.GetAll(includes: "Faculty").OrderBy(o => o.Faculty.Name).ToList());
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

            return View(departmentCourseService.GetAll(x => x.Department_ID == id, includes: new string[] { "Term", "Course" }).OrderBy(o => o.Term.ID).ToList());
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
                departmentService.Add(Department);
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
            Department Department = departmentService.Get(x => x.ID == id);
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
                departmentService.Attach(Department);
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
            Department Department = departmentService.Get(x => x.ID == id);
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
            Department Department = departmentService.Get(x => x.ID == id);
            departmentService.Delete(Department);
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
                departmentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
