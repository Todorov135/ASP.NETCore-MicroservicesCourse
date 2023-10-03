namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;

    public interface IBaseService
    {
        Task<ResponceDto?> SendAsync(RequestDto requestDto);
    }
}
