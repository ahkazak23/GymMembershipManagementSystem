using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Models.Entities;

namespace DAL.Repositories
{
    public class AdminRepository
    {
        /// <summary>
        /// Adds a new admin to the database with a hashed password.
        /// </summary>
        /// <param name="admin">Admin object containing username and plain text password.</param>
        public void AddAdmin(Admin admin)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                // Hash the password using bcrypt
                admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(admin.PasswordHash);

                string query = "INSERT INTO Admins (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", admin.Username);
                    command.Parameters.AddWithValue("@PasswordHash", admin.PasswordHash);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Validates an admin's login credentials by comparing the provided password with the stored hash.
        /// </summary>
        /// <param name="username">Admin's username.</param>
        /// <param name="plainTextPassword">Admin's plain text password.</param>
        /// <returns>True if the credentials are valid, false otherwise.</returns>
        public bool ValidateAdmin(string username, string plainTextPassword)
        {
            var admin = GetAdminByUsername(username);
            if (admin == null) return false;

            // Compare the provided password with the stored hash
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, admin.PasswordHash);
        }

        /// <summary>
        /// Checks if an admin with the given username already exists in the database.
        /// </summary>
        /// <param name="username">Admin's username.</param>
        /// <returns>True if the admin exists, false otherwise.</returns>
        public bool AdminExists(string username)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Retrieves an admin's details by their username.
        /// </summary>
        /// <param name="username">Admin's username.</param>
        /// <returns>An Admin object or null if not found.</returns>
        public Admin GetAdminByUsername(string username)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT AdminID, Username, PasswordHash FROM Admins WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Admin
                            {
                                AdminID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Updates an admin's password securely.
        /// </summary>
        /// <param name="username">Admin's username.</param>
        /// <param name="newPlainTextPassword">New plain text password.</param>
        public void UpdateAdminPassword(string username, string newPlainTextPassword)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "UPDATE Admins SET PasswordHash = @PasswordHash WHERE Username = @Username";
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPlainTextPassword);

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes an admin by their username.
        /// </summary>
        /// <param name="username">Admin's username.</param>
        public void DeleteAdmin(string username)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "DELETE FROM Admins WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves a list of all admins.
        /// </summary>
        /// <returns>List of Admin objects.</returns>
        public List<Admin> GetAllAdmins()
        {
            var admins = new List<Admin>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT AdminID, Username, PasswordHash FROM Admins";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admins.Add(new Admin
                        {
                            AdminID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2)
                        });
                    }
                }
            }

            return admins;
        }
    }
}
