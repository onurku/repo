using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gtsiparis_45;

namespace gtsiparis_45.Controllers
{
    public class KullaniciController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kullanici
        public ActionResult Index()
        {
            var kullanici = db.Kullanici.Include(k => k.Grup).Include(k => k.Rol);
            return View(kullanici.ToList());
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi");
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi");
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adi,Soyadi,Email,Telefon,Parola,ParolaSalt,Aktif,Grup_Id,Rol_Id")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kullanici.Grup_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", kullanici.Rol_Id);
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kullanici.Grup_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", kullanici.Rol_Id);
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,Soyadi,Email,Telefon,Parola,ParolaSalt,Aktif,Grup_Id,Rol_Id")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kullanici.Grup_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", kullanici.Rol_Id);
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
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
