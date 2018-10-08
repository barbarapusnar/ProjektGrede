using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNet.Identity;

namespace ProjektGrede
{

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("PredavateljNET") { }

        static AppDbContext() 
        { 
            Database.SetInitializer<AppDbContext>(new IdentityDbInit());
        }

        public virtual IDbSet<AppUser> Users { get; set; }

        public static AppDbContext Create() 
        {
            return new AppDbContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<ProjektGrede.LoginModel> LoginModels { get; set; }

        public System.Data.Entity.DbSet<ProjektGrede.AppUser> AppUsers { get; set; }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppDbContext>
    {
    }
}
