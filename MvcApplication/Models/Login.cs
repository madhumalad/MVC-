using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models
{
    public class Login
    {
       
        [Required(ErrorMessage ="UserName is Required")]
        [MinLength(5,ErrorMessage ="UserName shoul be more than 5 letter")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Keep me Signed In")]
        public bool RememberMe { get; set; }
        
    }
}