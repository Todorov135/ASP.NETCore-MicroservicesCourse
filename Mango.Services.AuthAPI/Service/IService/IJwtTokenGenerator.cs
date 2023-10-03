namespace Mango.Services.AuthAPI.Service.IService
{
    using Mango.Services.AuthAPI.Models;

    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
