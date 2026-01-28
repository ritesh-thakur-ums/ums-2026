namespace UMS.Api.DTOs.Auth
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

    }
}
