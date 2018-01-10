using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
  public class Cikolata
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        public string ResimPath { get; set; }
        public decimal Fiyat { get; set; }

        //Mapping
        public virtual ICollection<Siparis> Siparisler { get; set; }
    }
}
