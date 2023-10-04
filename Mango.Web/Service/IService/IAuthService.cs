namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;
    using Mango.Web.Models.AuthDtos;

    public interface IAuthService
    {
        Task<ResponceDto?> LoginAsync(LoginRequestDto loginRequestDto); 
        Task<ResponceDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto); 
        Task<ResponceDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto); 
    }
}
