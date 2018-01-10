using GiftBox.DAL;
using GiftBox.UI.İdentity;
using GiftBox.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GiftBox.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult Cicek()
        {
            return View();
        }
        public ActionResult Cikolata()
        {
            return View();
        }
        public ActionResult Kutu()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        // Sipariş Ekleme
        private GiftBoxContext db = new GiftBoxContext();
        [Authorize(Roles = "Admin,Users")]
        public ActionResult Siparis()
        {
            ViewBag.CicekID = new SelectList(db.Cicekler, "ID", "Ad");
            ViewBag.CikolataID = new SelectList(db.Cikolatalar, "ID", "Ad");
            ViewBag.KutuID = new SelectList(db.Kutular, "ID", "ID");
            ViewBag.KullaniciID = new SelectList(db.Users, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Siparis([Bind(Include = "ID,KullaniciID,CicekID,CikolataID,KutuID,Metin,ResimPath,Adres,TeslimTarih")] Siparis siparis, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath != null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/Fotograf/" + newfoto);
                siparis.ResimPath = "Fotograf/" + newfoto;
            }

            #endregion
            ApplicationUser kullanici =db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            siparis.KullaniciID = kullanici.Id;     
            if (ModelState.IsValid)
            {
                db.Siparisler.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.CicekID = new SelectList(db.Cicekler, "ID", "Ad", siparis.CicekID);
            ViewBag.CikolataID = new SelectList(db.Cikolatalar, "ID", "Ad", siparis.CikolataID);
            ViewBag.KutuID = new SelectList(db.Kutular, "ID", "ID", siparis.KutuID);
            ViewBag.KullaniciID = new SelectList(db.Users, "Id", "Name", siparis.KullaniciID);
            return View(siparis);
        }
    }
}