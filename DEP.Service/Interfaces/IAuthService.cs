using DEP.Repository.Models;
using DEP.Service.ViewModels;
using static DEP.Service.Services.AuthService;

namespace DEP.Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticatedResponse> Login(LoginViewModel loginRequest);
        Task<ChangePasswordResult> ChangePassword(ChangePasswordViewModel viewModel);
        Task<bool> ResetPassword(int userId);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateJwtToken(User user);
        Task<string> CreateRefreshToken();
    }
}
