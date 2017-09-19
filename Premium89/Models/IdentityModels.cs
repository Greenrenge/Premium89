using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Premium89.Migrations;
using Premium89.Models.Shopping;
using System.Collections.Generic;

namespace Premium89.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser():base()
        {
            Orders = new HashSet<Order>();
        }
        //ApplicationUser newUser = new ApplicationUser(); วิธีใช้?
        //var claims = await ApplicationUser.GenerateUserIdentityAsync(manager);
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set;}
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<SizeGroup> SizeGroups { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //https://stackoverflow.com/questions/28531201/entitytype-identityuserlogin-has-no-key-defined-define-the-key-for-this-entit
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Category>()
                    .HasMany(e => e.ChildCates)
                    .WithOptional(x => x.ParentCate)
                    .HasForeignKey(e => e.ParentCategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}