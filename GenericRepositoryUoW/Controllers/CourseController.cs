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
    /// Course Controller 
    /// </summary>
    public class CourseController : Controller
    {
        /// <summary>
        /// GenericUoW and RepositoryContext Instances
        /// </summary>
        private readonly GenericUoW UoW = null;
        private readonly RepositoryContext _context = null;

        /// <summary>
        /// CourseController constructor where UoW instance sets
        /// </summary>
        public CourseController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW = new GenericUoW(this._context);
        }

        /// <summary>
        /// Course/Index views corresponding action
        /// </summary>
        /// <returns>Index view with Course List Model</returns>
        public ActionResult Index()
        {
            return View(UoW.Repository<Course>().GetAll(includes: "lstTest").ToList());
        }

        /// <summary>
        /// GET: Course/Details views corresponding action
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns>Details view with Test list that has given Course id</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Test> lstTest = UoW.Repository<Test>().GetAll(x => x.Course_ID == id, includes: new string[] { "Year", "TestType" }).OrderBy(o => o.Year.Name).ToList();
            if (lstTest.Count == 0)
            {
                return View(new List<Test>());
            }
            return View(lstTest);
        }

        /// <summary>
        /// GET: Course/Create views corresponding action
        /// </summary>
        /// <returns>Empty form view to Create new Course</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Course/Create Insert operation
        /// </summary>
        /// <param name="Course">Course to insert</param>
        /// <returns>View with inserted Course model</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Course Course)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Course>().Add(Course);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Course);
        }

        /// <summary>
        /// GET: Course/Edit views corresponding action
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns>Course/Edit view with Course that has given id</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course Course = UoW.Repository<Course>().Get(x => x.ID == id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        /// <summary>
        /// POST: Course/Create Update operation
        /// </summary>
        /// <param name="Course">Course to edit</param>
        /// <returns>Corresponding view with its new value</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Course Course)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Course>().Attach(Course);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Course);
        }

        /// <summary>
        /// GET: Course/Delete views corresponding action
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course Course = UoW.Repository<Course>().Get(x => x.ID == id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        /// <summary>
        /// POST: Course/Delete Delete operation
        /// </summary>        
        /// <param name="id">Course id</param>
        /// <returns>Redirected to Course/Index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course Course = UoW.Repository<Course>().Get(x => x.ID == id);
            UoW.Repository<Course>().Delete(Course);
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
