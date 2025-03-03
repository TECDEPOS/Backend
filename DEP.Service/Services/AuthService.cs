﻿using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DEP.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepo;
        private readonly IConfiguration configuration;

        public AuthService(IUserRepository userRepo, IConfiguration configuration)
        {
            this.userRepo = userRepo;
            this.configuration = configuration;
        }

        public async Task<AuthenticatedResponse> Login(LoginViewModel loginRequest)
        {
            var user = await userRepo.GetUserByUsername(loginRequest.Username);

            if (user is null)
            {
                return null;
            }

            // Check if password is correct
            if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            string newAccessToken = CreateJwtToken(user);
            string newRefreshToken = await CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryDate = DateTime.Now.AddDays(1);
            await userRepo.UpdateUser(user);

            AuthenticatedResponse auth = new AuthenticatedResponse()
            {
                //UserId = user.UserId,
                //Name = user.Name,
                //UserRole = user.UserRole,
                //Username = loginRequest.Username,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                PasswordExpiryDate = user.PasswordExpiryDate,
            };

            return auth;
        }

        public enum ChangePasswordResult
        {
            Success,
            UserNotFound,
            WrongOldPassword,
            Failure
        }

        public async Task<ChangePasswordResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var user = await userRepo.GetUserById(viewModel.UserId);

            if (user is null)
            {
                return ChangePasswordResult.UserNotFound;
            }

            // Verify that the old password is correct
            if (!VerifyPasswordHash(viewModel.OldPassword, user.PasswordHash, user.PasswordSalt))
            {
                return ChangePasswordResult.WrongOldPassword;
            }

            try
            {
                // Create new passwordHash and passwordSalt for the new password
                CreatePasswordHash(viewModel.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PasswordExpiryDate = DateTime.Now.AddMonths(3);

                await userRepo.UpdateUser(user);

                return ChangePasswordResult.Success;
            }
            catch
            {
                return ChangePasswordResult.Failure;
            }
        }

        public async Task<bool> ResetPassword(int userId)
        {
            var user = await userRepo.GetUserById(userId);

            if (user is null)
            {
                return false;
            }

            var newPassword = configuration.GetSection("AppSettings:Password").Value;

            //Create new passwordHash and passwordSalt for the new password
            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            await userRepo.UpdateUser(user);
            return true;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateJwtToken(User user)
        {
            // Adding claims, claims are Key-Value pairs that can be used after the token is decoded.
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                new Claim("userId", user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name.ToString()),
                //new Claim(ClaimTypes.NameIdentifier, user.Name.ToString()),
                new Claim("roleId", ((int)user.UserRole).ToString())
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(5),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public async Task<string> CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            // Check if token exists in the Database already.
            var tokenInUser = await userRepo.GetUserByRefreshToken(refreshToken);
            if (tokenInUser is not null)
            {
                // If token already exists then run the method again.
                return await CreateRefreshToken();
            }
            return refreshToken;
        }
    }
}
