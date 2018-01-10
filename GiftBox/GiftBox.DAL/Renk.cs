using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
    public class Renk
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        //Mapping
        public virtual ICollection<Cicek> Cicekler { get; set; }
        public virtual ICollection<Kutu> Kutular { get; set; }
    }
}
