using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
    public class Cicek
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        public string ResimPath { get; set; }
        public decimal Fiyat { get; set; }
        public int RenkID { get; set; }


        //Mapping
        [ForeignKey("RenkID")]
        public virtual Renk Renk{ get; set; }

        public virtual ICollection<Siparis> Siparisler { get; set; }

    }
}
