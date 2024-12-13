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
        /// Registers a new admin.
        /// </summary>
        /// <param name="username">The username of the admin.</param>
        /// <param name="plainTextPassword">The plain text password of the admin.</param>
        /// <exception cref="ArgumentException">Thrown if username or password is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the username already exists.</exception>
        public void RegisterAdmin(string username, string plainTextPassword)
        {
            ValidateUsername(username);
            ValidatePassword(plainTextPassword);

            if (_adminRepository.AdminExists(username))
            {
                throw new InvalidOperationException("An admin with this username already exists.");
            }

            _adminRepository.AddAdmin(new Admin
            {
                Username = username,
                PasswordHash = plainTextPassword
            });
        }

        /// <summary>
        /// Logs in an admin by validating their credentials.
        /// </summary>
        /// <param name="username">The username of the admin.</param>
        /// <param name="plainTextPassword">The plain text password of the admin.</param>
        /// <returns>True if the credentials are valid; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if username or password is invalid.</exception>
        public bool LoginAdmin(string username, string plainTextPassword)
        {
            ValidateUsername(username);
            ValidatePassword(plainTextPassword);

            return _adminRepository.ValidateAdmin(username, plainTextPassword);
        }

        /// <summary>
        /// Validates the format of the username.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <exception cref="ArgumentException">Thrown if the username is invalid.</exception>
        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }

            if (username.Length < 3 || username.Length > 20)
            {
                throw new ArgumentException("Username must be between 3 and 20 characters.");
            }

            if (!IsValidUsername(username))
            {
                throw new ArgumentException("Username can only contain letters, numbers, and underscores.");
            }
        }

        /// <summary>
        /// Validates the format of the password.
        /// </summary>
        /// <param name="plainTextPassword">The password to validate.</param>
        /// <exception cref="ArgumentException">Thrown if the password is invalid.</exception>
        private void ValidatePassword(string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            if (plainTextPassword.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            if (!HasRequiredPasswordComplexity(plainTextPassword))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
            }
        }

        /// <summary>
        /// Checks if a username is valid.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the username is valid; otherwise, false.</returns>
        private bool IsValidUsername(string username)
        {
            // Simple regex for alphanumeric and underscores
            return System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$");
        }

        /// <summary>
        /// Checks if a password meets complexity requirements.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password meets requirements; otherwise, false.</returns>
        private bool HasRequiredPasswordComplexity(string password)
        {
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasNumber = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUppercase = true;
                if (char.IsLower(c)) hasLowercase = true;
                if (char.IsDigit(c)) hasNumber = true;
                if (!char.IsLetterOrDigit(c)) hasSpecial = true;

                if (hasUppercase && hasLowercase && hasNumber && hasSpecial)
                    return true;
            }

            return false;
        }
    }
}
