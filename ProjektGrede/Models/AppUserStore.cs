using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace ProjektGrede
{
    public class AppUserStore : IUserStore<AppUser,long>, IUserPasswordStore<AppUser,long>, IUserSecurityStampStore<AppUser,long>
    {
        UserStore<AppIdentityUser> userStore = new UserStore<AppIdentityUser>(new AppDbContext());

        public AppUserStore() : this(new AppDbContext()) 
        {            
        }

        public AppUserStore(DbContext context) : base() 
        {
        }

        public Task CreateAsync(AppUser user)
        {
            var context = userStore.Context as AppDbContext;
            context.Users.Add(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(AppUser user)
        {
            var context = userStore.Context as AppDbContext;
            context.Users.Remove(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }

        public Task<AppUser> FindByIdAsync(long id)
        {
            var context = userStore.Context as AppDbContext;
            return context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public Task<AppUser> FindByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> FindByNameAsync(string userName)
        {
            var context = userStore.Context as AppDbContext;
            return context.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(AppUser user)
        {
            var context = userStore.Context as AppDbContext;
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            userStore.Dispose();
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync((AppIdentityUser)identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);
            SetApplicationUser(user, identityUser);
            return task;
        }

        public Task<string> GetSecurityStampAsync(AppUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetSecurityStampAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }

        public Task SetSecurityStampAsync(AppUser user, string stamp)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetSecurityStampAsync(identityUser, stamp);
            SetApplicationUser(user, identityUser);
            return task;
        }

        private static void SetApplicationUser(AppUser user, AppIdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
            user.Id = long.Parse(identityUser.Id);
            user.UserName = identityUser.UserName;
        }

        private AppIdentityUser ToIdentityUser(AppUser user)
        {
            return new AppIdentityUser
            {
                Id = user.Id.ToString(),
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName,
            };
        }
    }
}