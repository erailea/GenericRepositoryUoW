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
    public class CourseController : Controller
    {
        private readonly GenericUoW UoW = null;
        private readonly RepositoryContext _context = null;

        public CourseController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW = new GenericUoW(this._context);
        }

        // GET: Test
        public ActionResult Index()
        {
            return View(UoW.Repository<Course>().GetAll(includes: "lstTest").ToList());
        }

        // GET: Course/Details/5
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

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Course/Edit/5
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

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Course/Delete/5
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

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course Course = UoW.Repository<Course>().Get(x => x.ID == id);
            UoW.Repository<Course>().Delete(Course);
            UoW.SaveChanges();
            return RedirectToAction("Index");
        }

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
