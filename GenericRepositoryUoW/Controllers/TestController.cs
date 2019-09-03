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
    public class TestController : Controller
    {
        private readonly GenericUoW UoW2 = null;
        private readonly RepositoryContext _context = null;

        public TestController()
        {
            if (this._context == null)
            {
                this._context = new RepositoryContext();
            }
            this.UoW2 = new GenericUoW(this._context);
        }

        // GET: Test
        public ActionResult Index()
        {
            return View(UoW2.Repository<Test>().GetAll().ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW2.Repository<Test>().Get(x => x.ID == id, new string[] { "Year", "TestType", "Course", "lstQuestion" });
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year,Term")] Test test)
        {
            if (ModelState.IsValid)
            {
                UoW2.Repository<Test>().Add(test);
                UoW2.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW2.Repository<Test>().Get(x => x.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year,Term")] Test test)
        {
            if (ModelState.IsValid)
            {
                UoW2.Repository<Test>().Attach(test);
                UoW2.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = UoW2.Repository<Test>().Get(x => x.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = UoW2.Repository<Test>().Get(x => x.ID == id);
            UoW2.Repository<Test>().Delete(test);
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
