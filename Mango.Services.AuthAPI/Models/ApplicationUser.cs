namespace Mango.Services.AuthAPI.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
