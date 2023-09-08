namespace BlogNoticias.Api.Models.Auth
{
    public class ResponseModel
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
