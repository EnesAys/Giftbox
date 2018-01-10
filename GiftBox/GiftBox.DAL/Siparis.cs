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
    public class Siparis
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciID { get; set; }
        [Display(Name ="Çiçek")]
        public int? CicekID { get; set; }
        [Display(Name = "Çikolata")]
        public int? CikolataID { get; set; }
        [Display(Name = "Kutu")]
        public int? KutuID { get; set; }
     
        [DataType(DataType.MultilineText)]
        public string Metin { get; set; }
  
        public string ResimPath { get; set; }
        public string Adres { get; set; }
        [Display(Name = "Teslim Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TeslimTarih { get; set; }

        //Mapping
        [ForeignKey("KullaniciID")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("CicekID")]
        public virtual Cicek Cicek { get; set; }
        [ForeignKey("CikolataID")]
        public virtual Cikolata Cikolata { get; set; }
        [ForeignKey("KutuID")]
        public virtual Kutu Kutu { get; set; }
    }
}
