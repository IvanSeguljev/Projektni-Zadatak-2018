//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projektni_centar_zadatak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class LoginUser
    {
        
        [DisplayName("Korisnicko ime")]
        [Required(ErrorMessage = "Ovo polje mora biti popunjeno")]
        public string Username { get; set; }
        [DisplayName("Lozinka")]
        [Required(ErrorMessage = "Ovo polje mora biti popunjeno")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Pravo pristupa")]
        [Range(1,3,ErrorMessage ="Pravo pristupa mora biti izmedju 1 i 3: 1 - Korisnik sa pravom citanja, 2 - Korisnik sa pravom citanja i pisanja, 3 - Administrator")]
        public Nullable<int> PravoPristupa { get; set; }
        public string LoginError = null;

        public bool greska = false;
    }
}
