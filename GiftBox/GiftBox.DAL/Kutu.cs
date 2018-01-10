using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
    public class Kutu
    {
        [Key]
        public int ID { get; set; }
        public int SekilID { get; set; }
        public int RenkID { get; set; }

        //Mapping
        [ForeignKey("SekilID")]
        public virtual Sekil Sekil{ get; set; }
        [ForeignKey("RenkID")]
        public virtual Renk Renk{ get; set; }
        public virtual ICollection<Siparis> Siparisler { get; set; }
    }
}
