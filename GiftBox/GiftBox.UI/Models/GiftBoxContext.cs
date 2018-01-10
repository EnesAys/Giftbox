using GiftBox.DAL;
using GiftBox.UI.İdentity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GiftBox.UI.Models
{
    public class GiftBoxContext: IdentityDbContext<ApplicationUser>
    {
        public GiftBoxContext() : base("GiftBoxCon")
        {

        }
        public DbSet<Cikolata> Cikolatalar { get; set; }
        public DbSet<Cicek> Cicekler { get; set; }
        public DbSet<Kutu> Kutular { get; set; }
        public DbSet<Renk> Renkler { get; set; }
        public DbSet<Sekil> Sekiller { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

     
    }
}