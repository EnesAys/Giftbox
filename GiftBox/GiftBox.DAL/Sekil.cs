using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftBox.DAL
{
    public class Sekil
    {
        [Key]
        public int ID { get; set; }
        public string Tur { get; set; }
        public string ResimPath { get; set; }

        //Mapping
        public virtual ICollection<Kutu> Kutular { get; set; }
    }
}
