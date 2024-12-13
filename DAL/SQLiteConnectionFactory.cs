using System.Data.SQLite;

namespace DAL
{
    public static class SQLiteConnectionFactory
    {
        private static readonly string _realConnectionString = "Data Source=C:\\Users\\FangYuan\\RiderProjects\\GymManagement\\gym.db;";

        // Creates a connection to the real database
        public static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection(_realConnectionString);
            connection.Open();
            return connection;
        }

        // Creates an in-memory database connection for testing
        public static SQLiteConnection CreateInMemoryConnection()
        {
            var connection = new SQLiteConnection("Data Source=:memory:;Version=3;");
            connection.Open();

            // Example of initializing schema for testing
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE Members (
                        Id INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL,
                        Email TEXT NOT NULL
                    );
                ";
                command.ExecuteNonQuery();
            }

            return connection;
        }
    }
}