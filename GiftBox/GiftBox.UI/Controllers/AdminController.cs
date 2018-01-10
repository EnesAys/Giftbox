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

namespace GiftBox.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        GiftBoxContext db = new GiftBoxContext();
        // GET: Admin
        public ActionResult Index()
        {
            var siparisler = db.Siparisler.Include(s => s.Cicek).Include(s => s.Cikolata).Include(s => s.Kutu).Include(s => s.User);
            return View(siparisler.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparisler.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparisler.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparisler.Find(id);
            db.Siparisler.Remove(siparis);
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