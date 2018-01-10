using GiftBox.DAL;
using GiftBox.UI.İdentity;
using GiftBox.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiftBox.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GiftBoxContext db = new GiftBoxContext();
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(roleStore);
            if (!roleManager.RoleExists("Admin"))
            {
                ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem yöneticisi");
                roleManager.Create(adminRole);
            }
            if (!roleManager.RoleExists("User"))
            {
                ApplicationRole userRole = new ApplicationRole("User", "Sistem kullanıcısı, yorum eklemek için gereklidir");
                roleManager.Create(userRole);
            }
        }
    }
}
