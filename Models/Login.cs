using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("Ben hatırla")]
        public bool RememberMe { get; set; }
    }
}