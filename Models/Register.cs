using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Kullanıcı adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("E-posta")]
        [EmailAddress(ErrorMessage ="E-posta adresinizi düzgün giriniz.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre tekrar")]
        [Compare("Password",ErrorMessage ="Şifreleriniz uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}