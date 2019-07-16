using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BACommerce.Classes
{
    public class AdminVM
    {
        public int Rights { get; set; }

        [
            Required(ErrorMessage = "Admin Name giriniz."),
            DisplayName("Kullanıcı Adı")
        ]
        public string AdminName { get; set; }

        [
            Required(ErrorMessage = "Paralonızı Giriniz."),
            DisplayName("Parola")
        ]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool IsPersistant { get; set; }
    }
}
