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
    public class CiceksController : Controller
    {
        private GiftBoxContext db = new GiftBoxContext();

        // GET: Ciceks
        public ActionResult Index()
        {
            var cicekler = db.Cicekler.Include(c => c.Renk);
            return View(cicekler.ToList());
        }

        // GET: Ciceks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cicek cicek = db.Cicekler.Find(id);
            if (cicek == null)
            {
                return HttpNotFound();
            }
            return View(cicek);
        }

        // GET: Ciceks/Create
        public ActionResult Create()
        {
            ViewBag.RenkID = new SelectList(db.Renkler, "ID", "Ad");
            return View();
        }

        // POST: Ciceks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,ResimPath,Fiyat,RenkID")] Cicek cicek, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Cicek/" + newfoto);
                cicek.ResimPath = "Cicek/" + newfoto;
            }

            #endregion
            if (ModelState.IsValid)
            {
                db.Cicekler.Add(cicek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RenkID = new SelectList(db.Renkler, "ID", "Ad", cicek.RenkID);
            return View(cicek);
        }

        // GET: Ciceks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cicek cicek = db.Cicekler.Find(id);
            if (cicek == null)
            {
                return HttpNotFound();
            }
            ViewBag.RenkID = new SelectList(db.Renkler, "ID", "Ad", cicek.RenkID);
            return View(cicek);
        }

        // POST: Ciceks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,ResimPath,Fiyat,RenkID")] Cicek cicek, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Cicek/" + newfoto);
                cicek.ResimPath = "Cicek/" + newfoto;
            }

            #endregion
            if (ModelState.IsValid)
            {
                db.Entry(cicek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RenkID = new SelectList(db.Renkler, "ID", "Ad", cicek.RenkID);
            return View(cicek);
        }

        // GET: Ciceks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cicek cicek = db.Cicekler.Find(id);
            if (cicek == null)
            {
                return HttpNotFound();
            }
            return View(cicek);
        }

        // POST: Ciceks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cicek cicek = db.Cicekler.Find(id);
            db.Cicekler.Remove(cicek);
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
