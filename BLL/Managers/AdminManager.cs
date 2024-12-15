using System;
using DAL.Repositories;
using Models.Entities;

namespace BLL.Managers
{
    public class AdminManager
    {
        private readonly AdminRepository _adminRepository;

        public AdminManager()
        {
            _adminRepository = new AdminRepository();
        }

        /// <summary>
        /// Registers a new admin with a validated username and password.
        /// </summary>
        /// <param name="username">The admin's username.</param>
        /// <param name="plainTextPassword">The plain text password.</param>
        public void RegisterAdmin(string username, string plainTextPassword)
        {
            ValidateUsername(username);
            ValidatePassword(plainTextPassword);

            if (_adminRepository.AdminExists(username))
            {
                throw new InvalidOperationException($"The username '{username}' is already taken.");
            }

            _adminRepository.AddAdmin(new Admin
            {
                Username = username,
                PasswordHash = plainTextPassword
            });
        }

        /// <summary>
        /// Validates admin login credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="plainTextPassword">The plain text password.</param>
        /// <returns>True if the credentials are valid, false otherwise.</returns>
        public bool LoginAdmin(string username, string plainTextPassword)
        {
            ValidateUsername(username);
            ValidatePassword(plainTextPassword);

            return _adminRepository.ValidateAdmin(username, plainTextPassword);
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }

            if (username.Length < 3 || username.Length > 20)
            {
                throw new ArgumentException("Username must be between 3 and 20 characters long.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ArgumentException("Username may only contain letters, numbers, and underscores.");
            }
        }

        private void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            if (password.Length < 5)
            {
                throw new ArgumentException("Password must be at least 5 characters long.");
            }

            if (!HasRequiredPasswordComplexity(password))
            {
                throw new ArgumentException("Password must include an uppercase letter, a lowercase letter, a number, and a special character.");
            }
        }

        private bool HasRequiredPasswordComplexity(string password)
        {
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (!char.IsLetterOrDigit(c)) hasSpecial = true;

                if (hasUpper && hasLower && hasDigit && hasSpecial) return true;
            }

            return false;
        }
    }
}
