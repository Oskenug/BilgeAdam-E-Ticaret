using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;   

namespace BACommerce.Classes
{
    public class LoginVM
    {
        [
            EmailAddress(ErrorMessage = "E-Posta formatında giriş yapınız."),
            Required(ErrorMessage = "E-Posta Adresinizi Giriniz"),
            DisplayName("E-posta")
        ]
       
        public string Email { get; set; }
        [
            Required(ErrorMessage = "Paralonızı Giriniz."),
            DisplayName("Parola")
        ]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool IsPersistant { get; set; }


    }
}