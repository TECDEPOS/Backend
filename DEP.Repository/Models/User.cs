﻿namespace DEP.Repository.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Byte[] PasswordHash { get; set; } = new byte[32];
        public Byte[] PasswordSalt { get; set; } = new byte[32];
        public UserRole UserRole { get; set; }
        public DateTime PasswordExpiryDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }
    }
}