using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjektGrede {

    public class LoginModel {
        public LoginModel()
        {
        }
        

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }       
    }
}
