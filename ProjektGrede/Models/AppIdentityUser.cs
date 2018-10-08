using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGrede
{
    public class AppIdentityUser : IdentityUser
    {
     
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public byte[] Slika { get; set; }
    }
}