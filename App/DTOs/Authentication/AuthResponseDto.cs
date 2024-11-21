namespace Assignment2.DTOs.Authentication
{
    public class AuthResponseDto
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
