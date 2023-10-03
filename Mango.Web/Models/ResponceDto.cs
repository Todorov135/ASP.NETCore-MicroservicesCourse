namespace Mango.Web.Models
{
    public class ResponceDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
    }
}
