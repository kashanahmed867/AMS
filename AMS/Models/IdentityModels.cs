using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserRole { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategorySub> CategoriesSub { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<OpeningClosing> OpeningClosings { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrder_Ch> PurchaseOrder_Ches { get; set; }

        public DbSet<PurchaseOrder_Pt> PurchaseOrder_Pts { get; set; }

        public DbSet<SaleOrder_Ch> SaleOrder_Ches { get; set; }

        public DbSet<SaleOrder_Pt> SaleOrder_Pts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<GatePass_Pt> GatePass_Pts { get; set; }

        public DbSet<GatePass_Ch> GatePass_Ches { get; set; }
    }
}