namespace Mango.Services.ShoppingCardAPI.Data
{
    using Mango.Services.ShoppingCardAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
            
        }

        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }


    }
}
