using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GiftBox.DAL;
using GiftBox.UI.Models;
using System.Web.Helpers;
using System.IO;

namespace GiftBox.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SekilsController : Controller
    {
        private GiftBoxContext db = new GiftBoxContext();

        // GET: Sekils
        public ActionResult Index()
        {
            return View(db.Sekiller.ToList());
        }

        // GET: Sekils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sekils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tur,ResimPath")] Sekil sekil, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Sekiller/" + newfoto);
                sekil.ResimPath = "Sekiller/" + newfoto;
            }

            #endregion
            if (ModelState.IsValid)
            {
                db.Sekiller.Add(sekil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sekil);
        }

        // GET: Sekils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sekil sekil = db.Sekiller.Find(id);
            if (sekil == null)
            {
                return HttpNotFound();
            }
            return View(sekil);
        }

        // POST: Sekils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tur,ResimPath")] Sekil sekil, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Sekiller/" + newfoto);
                sekil.ResimPath = "Sekiller/" + newfoto;
            }

            #endregion
            if (ModelState.IsValid)
            {
                db.Entry(sekil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sekil);
        }

        // GET: Sekils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sekil sekil = db.Sekiller.Find(id);
            if (sekil == null)
            {
                return HttpNotFound();
            }
            return View(sekil);
        }

        // POST: Sekils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sekil sekil = db.Sekiller.Find(id);
            db.Sekiller.Remove(sekil);
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
