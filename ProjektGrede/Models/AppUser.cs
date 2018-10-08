using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ProjektGrede
{
    public class AppUser :  IUser<long>
    { 
        public AppUser() 
        { 
        } 

        public AppUser(string uporabniskoIme): this() 
        { 
            UserName = uporabniskoIme; 
        } 
        public virtual long Id { get; set; } 
        public virtual string PasswordHash { get; set; } 
        public virtual string SecurityStamp { get; set; } 
        public virtual string UserName { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Priimek { get; set; }
        public virtual byte[] Slika { get; set; }
    }
   
    }


