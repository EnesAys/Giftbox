using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GiftBox.UI.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name="Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DogumTarih { get; set; }
        [Display(Name = "Profil Resmi")]
        public string ResimPath { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [MinLength(6,ErrorMessage = "Minimum 6 Kaarakter Olmalı")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}