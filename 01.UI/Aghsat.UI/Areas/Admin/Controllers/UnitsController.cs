using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;

namespace Aghsat.UI.Areas.Admin.Controllers
{
    public partial class UnitsController : Controller
    {
        private AghsatContext db = new AghsatContext();

        // GET: Admin/Units
        public virtual ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        // GET: Admin/Units/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Admin/Units/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "Id,Name,CreateDate,ModifeDate,IsDeleted,IsActive")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Admin/Units/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,Name,CreateDate,ModifeDate,IsDeleted,IsActive")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Admin/Units/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
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
