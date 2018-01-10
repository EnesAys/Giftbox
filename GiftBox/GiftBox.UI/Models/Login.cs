using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiftBox.UI.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}