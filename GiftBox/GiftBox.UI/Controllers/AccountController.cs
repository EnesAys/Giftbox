using GiftBox.DAL;
using GiftBox.UI.İdentity;
using GiftBox.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GiftBox.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            GiftBoxContext db = new GiftBoxContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public ActionResult Index()
        {
            return View();
        }


        #region ÜyeOL-Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model, HttpPostedFileBase ResimPath)
        {
            #region ResimEkleme
            if (ResimPath!=null)
            {
                WebImage img = new WebImage(ResimPath.InputStream);
                FileInfo fotoinfo = new FileInfo(ResimPath.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/İmages/UserProfile/" + newfoto);
                model.ResimPath = "UserProfile/" + newfoto;
            }
           

            #endregion
            if (ModelState.IsValid)
                {
               
                ApplicationUser user = new ApplicationUser();
              
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.DogumTarih = model.DogumTarih;
                user.ResimPath = model.ResimPath;
                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
                }
            }
            return View();
        }
        #endregion



        #region ÜyeGiris-Login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps, identity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");
                }
            }

            return View(model);
        }
        #endregion

        #region UyeCikis-LogOut
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
        #endregion


    }
}