namespace Mango.Services.AuthAPI.Service.IService
{
    using Mango.Services.AuthAPI.Models.Dto;

    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
