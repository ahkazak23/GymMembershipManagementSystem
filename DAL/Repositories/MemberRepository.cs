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
                string query = "INSERT INTO Members (FirstName, LastName, Phone, Email, DateOfBirth, MembershipType, StartDate, EndDate) " +
                               "VALUES (@FirstName, @LastName, @Phone, @Email, @DateOfBirth, @MembershipType, @StartDate, @EndDate)";
                
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Phone", member.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(member.Email) ? (object)DBNull.Value : member.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth == default ? (object)DBNull.Value : member.DateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                    command.Parameters.AddWithValue("@StartDate", member.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", member.EndDate.ToString("yyyy-MM-dd"));

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
                               "DateOfBirth = @DateOfBirth, MembershipType = @MembershipType, StartDate = @StartDate, EndDate = @EndDate " +
                               "WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", member.MemberID);
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Phone", member.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(member.Email) ? (object)DBNull.Value : member.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth == default ? (object)DBNull.Value : member.DateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                    command.Parameters.AddWithValue("@StartDate", member.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", member.EndDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
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
                string query = "SELECT MemberID, FirstName, LastName, Phone, Email, DateOfBirth, MembershipType, StartDate, EndDate FROM Members";

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
                            MembershipType = reader.GetString(6),
                            StartDate = DateTime.Parse(reader.GetString(7)),
                            EndDate = DateTime.Parse(reader.GetString(8))
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
                string query = "SELECT * FROM Members WHERE MemberID = @MemberID";

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
                                MembershipType = reader.GetString(6),
                                StartDate = DateTime.Parse(reader.GetString(7)),
                                EndDate = DateTime.Parse(reader.GetString(8))
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
