using DEP.Repository.Models;

namespace DEP.Service.ViewModels
{
    public class AuthenticatedResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime PasswordExpiryDate { get; set; }
    }
}
