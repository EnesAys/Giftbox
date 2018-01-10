using GiftBox.UI.İdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
    public class Fotograf
    {
        [Key]
        public int ID { get; set; }
        public string Metin { get; set; }
        public string KullaniciID { get; set; }
        public string ResimPath { get; set; }

        [ForeignKey("KullaniciID")]
        public decimal Fiyat { get { return 5; } }
        public virtual ApplicationUser User { get; set; }

    }
}
