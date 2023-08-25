using DEP.Repository.Models;
using DEP.Service.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticatedResponse> Login(LoginViewModel loginRequest);
        Task<bool> ChangePassword(ChangePasswordViewModel viewModel);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateJwtToken(User user);
        Task<string> CreateRefreshToken();
    }
}
