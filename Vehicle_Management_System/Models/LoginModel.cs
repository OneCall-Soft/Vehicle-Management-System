using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle_Management_System.Models
{
    public class LoginModel
    {
        [Display(Name = "ID")]
        public string id { get; set; }

        [Display(Name = "UserID")]
        [Required(ErrorMessage = "Please enter userid!")]
        public string userid { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password!")]
        [DataType(DataType.Password)]
        public string userpass { get; set; }
    }
}