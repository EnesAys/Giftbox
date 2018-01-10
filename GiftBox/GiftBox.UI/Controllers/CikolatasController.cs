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
    public class CikolatasController : Controller
    {
        private GiftBoxContext db = new GiftBoxContext();

        // GET: Cikolatas
        public ActionResult Index()
        {
            return View(db.Cikolatalar.ToList());
        }

        // GET: Cikolatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cikolata cikolata = db.Cikolatalar.Find(id);
            if (cikolata == null)
            {
                return HttpNotFound();
            }
            return View(cikolata);
        }

        // GET: Cikolatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cikolatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,ResimPath,Fiyat")] Cikolata cikolata, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Cikolata/" + newfoto);
                cikolata.ResimPath = "Cikolata/" + newfoto;
            }


            #endregion
            if (ModelState.IsValid)
            {
                db.Cikolatalar.Add(cikolata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cikolata);
        }

        // GET: Cikolatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cikolata cikolata = db.Cikolatalar.Find(id);
            if (cikolata == null)
            {
                return HttpNotFound();
            }
            return View(cikolata);
        }

        // POST: Cikolatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,ResimPath,Fiyat")] Cikolata cikolata, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Cikolata/" + newfoto);
                cikolata.ResimPath = "Cikolata/" + newfoto;
            }


            #endregion
            if (ModelState.IsValid)
            {
                db.Entry(cikolata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cikolata);
        }

        // GET: Cikolatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cikolata cikolata = db.Cikolatalar.Find(id);
            if (cikolata == null)
            {
                return HttpNotFound();
            }
            return View(cikolata);
        }

        // POST: Cikolatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cikolata cikolata = db.Cikolatalar.Find(id);
            db.Cikolatalar.Remove(cikolata);
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
