using System.Web.Mvc;

using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Web;

using System;
using System.Configuration;
using System.DirectoryServices.AccountManagement;


namespace ProjektGrede
{
    [Authorize]
    public class RacunController : Controller 
    {
      

        [AllowAnonymous]
        public ActionResult Prijava(string returnUrl) 
        {       
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Prijava(LoginModel details, string returnUrl) 
        {            
            if (ModelState.IsValid) 
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                var authService = new AdAuthenticationService(authenticationManager);

                var authenticationResult = authService.SignIn(details.UserName, details.Password);

                if (authenticationResult.IsSuccess)
                {
                    return RedirectToAction("Index", "PodatkiVnos");
                }
                else
                {
                    ModelState.AddModelError("", authenticationResult.ErrorMessage);
                }
            }

           
            ViewBag.returnUrl = returnUrl;
            ViewBag.Uporabnik = details.UserName;
            return View(details);
        }

        [Authorize]
        public ActionResult Odjava() 
        {
            AuthManager.SignOut();
           
            return RedirectToAction("Prijava", "Racun");
        }

        [AllowAnonymous]
        public ActionResult NapakaIdentitete()
        {
            return View("NapakaIdentitete");
        }

        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }

    public class AdAuthenticationService
    {
        public class AuthenticationResult
        {
            public AuthenticationResult(string errorMessage = null)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }
            public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
        }

        private readonly IAuthenticationManager authenticationManager;

        public AdAuthenticationService(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public AuthenticationResult SignIn(string username, string password)
        {
            string ADController = ConfigurationManager.ConnectionStrings["ADController"].ConnectionString;
            string ADDomain = ConfigurationManager.ConnectionStrings["ADDomain"].ConnectionString;
            string ADUserName = ConfigurationManager.ConnectionStrings["ADUserName"].ConnectionString;
            string ADPassword = ConfigurationManager.ConnectionStrings["ADPassword"].ConnectionString;

            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "c-dc1.c.scng.si:636", "dc=c,dc=scng,dc=si", ContextOptions.Negotiate, "RegisNET@c.scng.si", "California43");
            bool isAuthenticated = false;
            UserPrincipal userPrincipal = null;
            try
            {
                isAuthenticated = principalContext.ValidateCredentials(username, password, ContextOptions.Negotiate);
                if (isAuthenticated)
                {
                    username = username.ToLower();
                    userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, username);
                }
            }
            catch (Exception)
            {
                isAuthenticated = false;
                userPrincipal = null;
            }

            if (!isAuthenticated || userPrincipal == null)
            {
                return new AuthenticationResult("Napačno uporabniško ime ali geslo.");
            }
            else if (userPrincipal.IsAccountLockedOut())
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Račun nima dostopa do sistema Regis.NET.");
            }
            else if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Račun nima dostopa do sistema Regis.NET.");
            }
            else
            {
                if (!IsUserGroupMember(username, "RegisNET Group", principalContext))
                {
                    return new AuthenticationResult("Račun nima dostopa do sistema Regis.NET.");
                }
            }


            var identity = CreateIdentity(userPrincipal);

            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);


            return new AuthenticationResult();
        }

        private ClaimsIdentity CreateIdentity(UserPrincipal userPrincipal)
        {
            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.SamAccountName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));
            if (!String.IsNullOrEmpty(userPrincipal.EmailAddress))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress));
            }

            // add your own claims if you need to add more information stored on the cookie

            return identity;
        }

        public static bool IsUserGroupMember(string userPrincipalName, string groupname,PrincipalContext context)
        {
            GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupname);

            bool foundUser = false;

            foreach (var member in group.GetMembers(true))
            {
                try
                {
                    if (member.SamAccountName.Equals(userPrincipalName))
                    {
                        foundUser = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    foundUser = false;
                }
            }

            group.Dispose();
            return foundUser;
        }
    }    
}


