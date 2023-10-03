namespace Mango.Services.AuthAPI.Data
{
    using Mango.Services.AuthAPI.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContex : IdentityDbContext<ApplicationUser>
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
