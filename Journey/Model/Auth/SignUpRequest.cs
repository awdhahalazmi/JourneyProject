namespace Journy.Model.Auth
{
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
