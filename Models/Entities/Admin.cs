namespace Models.Entities
{
    public class Admin
    {
        public int AdminID { get; set; } // Primary key
        public string Username { get; set; } // Admin username
        public string PasswordHash { get; set; } // Hashed password
    }
}