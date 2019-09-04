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
    /// Test Controller 
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// GenericUoW and RepositoryContext Instances
        /// </summary>
        private readonly GenericUoW UoW = null;
        private readonly RepositoryContext _context = null;

        /// <summary>
        /// TestController constructor where UoW instance sets
        /// </summary>
        public TestController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW = new GenericUoW(this._context);
        }

        /// <summary>
        /// Test/Index views corresponding action
        /// </summary>
        /// <returns>Index view with Test List Model</returns>
        public ActionResult Index()
        {
            return View(UoW.Repository<Test>().GetAll().ToList());
        }

        /// <summary>
        /// GET: Test/Details views corresponding action
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Details view with Single Test that has given id</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW.Repository<Test>().Get(x => x.ID == id, new string[] { "Year", "TestType", "Course", "lstQuestion" });
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        /// <summary>
        /// GET: Test/Create views corresponding action
        /// </summary>
        /// <returns>Empty form view to Create new Test</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Test/Create Insert operation
        /// </summary>
        /// <param name="Test">Test to insert</param>
        /// <returns>View with inserted Test model</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year,Term")] Test test)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Test>().Add(test);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        /// <summary>
        /// GET: Test/Edit views corresponding action
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Test/Edit view with Test that has given id</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW.Repository<Test>().Get(x => x.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        /// <summary>
        /// POST: Test/Create Update operation
        /// </summary>
        /// <param name="Test">Test to edit</param>
        /// <returns>Corresponding view with its new value</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year,Term")] Test test)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Test>().Attach(test);
                UoW.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        /// <summary>
        /// GET: Test/Delete views corresponding action
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW.Repository<Test>().Get(x => x.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        /// <summary>
        /// POST: Test/Delete Delete operation
        /// </summary>        
        /// <param name="id">Test id</param>
        /// <returns>Redirected to Test/Index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = UoW.Repository<Test>().Get(x => x.ID == id);
            UoW.Repository<Test>().Delete(test);
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
