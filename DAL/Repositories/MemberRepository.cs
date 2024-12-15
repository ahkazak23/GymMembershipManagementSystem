using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Models.Entities;

namespace DAL.Repositories
{
    public class MemberRepository
    {
        /// <summary>
        /// Adds a new member to the database.
        /// </summary>
        /// <param name="member">Member object containing member details.</param>
        public void AddMember(Member member)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "INSERT INTO Members (FirstName, LastName, Phone, Email, DateOfBirth, Gender, MembershipType, StartDate, EndDate, IsActive) " +
                               "VALUES (@FirstName, @LastName, @Phone, @Email, @DateOfBirth, @Gender, @MembershipType, @StartDate, @EndDate, @IsActive)";
                
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Phone", member.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(member.Email) ? (object)DBNull.Value : member.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth == default ? (object)DBNull.Value : member.DateOfBirth.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Gender", member.Gender);
                    command.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                    command.Parameters.AddWithValue("@StartDate", member.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", member.EndDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@IsActive", member.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates an existing member in the database.
        /// </summary>
        /// <param name="member">Member object containing updated member details.</param>
        public void UpdateMember(Member member)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "UPDATE Members SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email, " +
                               "DateOfBirth = @DateOfBirth, Gender = @Gender, MembershipType = @MembershipType, StartDate = @StartDate, EndDate = @EndDate, IsActive = @IsActive " +
                               "WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", member.MemberID);
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Phone", member.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(member.Email) ? (object)DBNull.Value : member.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth == default ? (object)DBNull.Value : member.DateOfBirth.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Gender", member.Gender);
                    command.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                    command.Parameters.AddWithValue("@StartDate", member.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", member.EndDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@IsActive", member.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Member> GetMembersByExpirationDateRange(DateTime startDate, DateTime endDate)
        {
            var members = new List<Member>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = @"SELECT MemberID, FirstName, LastName, Phone, Email, DateOfBirth, MembershipType, StartDate, EndDate 
                         FROM Members
                         WHERE EndDate BETWEEN @StartDate AND @EndDate";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            members.Add(new Member
                            {
                                MemberID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DateOfBirth = reader.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(reader.GetString(5)),
                                MembershipType = reader.GetString(6),
                                StartDate = DateTime.Parse(reader.GetString(7)),
                                EndDate = DateTime.Parse(reader.GetString(8))
                            });
                        }
                    }
                }
            }

            return members;
        }
        public List<Member> GetMembersByStartDate(DateTime startDate, DateTime endDate)
        {
            var members = new List<Member>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT MemberID, FirstName, LastName, MembershipType, StartDate " +
                               "FROM Members WHERE StartDate BETWEEN @StartDate AND @EndDate";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            members.Add(new Member
                            {
                                MemberID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                MembershipType = reader.GetString(3),
                                StartDate = DateTime.Parse(reader.GetString(4))
                            });
                        }
                    }
                }
            }

            return members;
        }
        /// <summary>
        /// Retrieves the age distribution of members grouped into ranges.
        /// </summary>
        /// <returns>A dictionary where the key is the age range and the value is the member count.</returns>
        public Dictionary<string, int> GetAgeDistribution()
        {
            var ageDistribution = new Dictionary<string, int>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = @"
                    SELECT 
                        CASE 
                            WHEN (strftime('%Y', 'now') - strftime('%Y', DateOfBirth)) BETWEEN 18 AND 25 THEN '18-25'
                            WHEN (strftime('%Y', 'now') - strftime('%Y', DateOfBirth)) BETWEEN 26 AND 35 THEN '26-35'
                            WHEN (strftime('%Y', 'now') - strftime('%Y', DateOfBirth)) BETWEEN 36 AND 45 THEN '36-45'
                            WHEN (strftime('%Y', 'now') - strftime('%Y', DateOfBirth)) BETWEEN 46 AND 60 THEN '46-60'
                            WHEN (strftime('%Y', 'now') - strftime('%Y', DateOfBirth)) > 60 THEN '60+'
                            ELSE 'Unknown'
                        END AS AgeRange,
                        COUNT(*) AS MemberCount
                    FROM Members
                    GROUP BY AgeRange;
                ";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ageRange = reader.GetString(0); // AgeRange
                        int memberCount = reader.GetInt32(1);  // MemberCount
                        ageDistribution.Add(ageRange, memberCount);
                    }
                }
            }

            return ageDistribution;
        }
        public Dictionary<string, int> GetMembershipTypeDistribution()
        {
            var typeDistribution = new Dictionary<string, int>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = @"
            SELECT MembershipType, COUNT(*) AS MemberCount
            FROM Members
            GROUP BY MembershipType;
        ";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string membershipType = reader.GetString(0); // MembershipType
                        int memberCount = reader.GetInt32(1);        // MemberCount
                        typeDistribution.Add(membershipType, memberCount);
                    }
                }
            }

            return typeDistribution;
        }




        /// <summary>
        /// Deletes a member from the database.
        /// </summary>
        /// <param name="memberId">ID of the member to delete.</param>
        public void DeleteMember(int memberId)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "DELETE FROM Members WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all members from the database.
        /// </summary>
        /// <returns>List of Member objects.</returns>
        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT MemberID, FirstName, LastName, Phone, Email, DateOfBirth, Gender, MembershipType, StartDate, EndDate, IsActive FROM Members";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member
                        {
                            MemberID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateOfBirth = reader.IsDBNull(5) ? default : DateTime.Parse(reader.GetString(5)),
                            Gender = reader.GetString(6),
                            MembershipType = reader.GetString(7),
                            StartDate = DateTime.Parse(reader.GetString(8)),
                            EndDate = DateTime.Parse(reader.GetString(9)),
                            IsActive = reader.GetBoolean(10)
                        });
                    }
                }
            }

            return members;
        }

        /// <summary>
        /// Retrieves a member by their ID.
        /// </summary>
        /// <param name="memberId">ID of the member to retrieve.</param>
        /// <returns>Member object or null if not found.</returns>
        public Member GetMemberById(int memberId)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT MemberID, FirstName, LastName, Phone, Email, DateOfBirth, Gender, MembershipType, StartDate, EndDate, IsActive " +
                               "FROM Members WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Member
                            {
                                MemberID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DateOfBirth = reader.IsDBNull(5) ? default : DateTime.Parse(reader.GetString(5)),
                                Gender = reader.GetString(6),
                                MembershipType = reader.GetString(7),
                                StartDate = DateTime.Parse(reader.GetString(8)),
                                EndDate = DateTime.Parse(reader.GetString(9)),
                                IsActive = reader.GetBoolean(10)
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves active members from the database.
        /// </summary>
        /// <returns>List of active Member objects.</returns>
        public List<Member> GetActiveMembers()
        {
            var members = new List<Member>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT MemberID, FirstName, LastName, Phone, Email, DateOfBirth, Gender, MembershipType, StartDate, EndDate, IsActive " +
                               "FROM Members WHERE IsActive = 1";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member
                        {
                            MemberID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateOfBirth = reader.IsDBNull(5) ? default : DateTime.Parse(reader.GetString(5)),
                            Gender = reader.GetString(6),
                            MembershipType = reader.GetString(7),
                            StartDate = DateTime.Parse(reader.GetString(8)),
                            EndDate = DateTime.Parse(reader.GetString(9)),
                            IsActive = reader.GetBoolean(10)
                        });
                    }
                }
            }

            return members;
        }
    }
}
