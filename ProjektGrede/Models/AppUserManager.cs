using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ProjektGrede
{
    public class AppUserManager : UserManager<AppUser, long>
    {
        public AppUserManager(AppUserStore store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context) 
        {

            AppDbContext db = context.Get<AppDbContext>();
            AppUserManager manager = new AppUserManager(new AppUserStore(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            return manager;
        }
    }
}
