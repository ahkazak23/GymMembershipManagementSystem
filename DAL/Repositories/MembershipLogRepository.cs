using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Models.Entities;

namespace DAL.Repositories
{
    public class MembershipLogRepository
    {
        /// <summary>
        /// Adds a new membership log to the database.
        /// </summary>
        /// <param name="log">MembershipLog object containing log details.</param>
        public void AddLog(MembershipLog log) // Updated method name
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "INSERT INTO MembershipLogs (MemberID, EventDate, EventType) " +
                               "VALUES (@MemberID, @EventDate, @EventType)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", log.MemberID);
                    command.Parameters.AddWithValue("@EventDate", log.EventDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EventType", log.EventType);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves the most recent membership logs, limited by the specified number.
        /// </summary>
        /// <param name="limit">The maximum number of logs to retrieve.</param>
        /// <returns>List of MembershipLog objects.</returns>
        public List<MembershipLog> GetRecentLogs(int limit)
        {
            var logs = new List<MembershipLog>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT LogID, MemberID, EventDate, EventType " +
                               "FROM MembershipLogs ORDER BY EventDate DESC LIMIT @Limit";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Limit", limit);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new MembershipLog
                            {
                                LogID = reader.GetInt32(0),
                                MemberID = reader.GetInt32(1),
                                EventDate = DateTime.Parse(reader.GetString(2)),
                                EventType = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Retrieves all membership logs for a specific member.
        /// </summary>
        /// <param name="memberId">ID of the member.</param>
        /// <returns>List of MembershipLog objects.</returns>
        public List<MembershipLog> GetLogsByMemberId(int memberId)
        {
            var logs = new List<MembershipLog>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT LogID, MemberID, EventDate, EventType FROM MembershipLogs WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new MembershipLog
                            {
                                LogID = reader.GetInt32(0),
                                MemberID = reader.GetInt32(1),
                                EventDate = DateTime.Parse(reader.GetString(2)),
                                EventType = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Retrieves all membership logs within a specific date range.
        /// </summary>
        /// <param name="startDate">Start date of the range.</param>
        /// <param name="endDate">End date of the range.</param>
        /// <returns>List of MembershipLog objects.</returns>
        public List<MembershipLog> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            var logs = new List<MembershipLog>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT LogID, MemberID, EventDate, EventType " +
                               "FROM MembershipLogs WHERE EventDate BETWEEN @StartDate AND @EndDate";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new MembershipLog
                            {
                                LogID = reader.GetInt32(0),
                                MemberID = reader.GetInt32(1),
                                EventDate = DateTime.Parse(reader.GetString(2)),
                                EventType = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Retrieves all membership logs from the database.
        /// </summary>
        /// <returns>List of MembershipLog objects.</returns>
        public List<MembershipLog> GetAllLogs()
        {
            var logs = new List<MembershipLog>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT LogID, MemberID, EventDate, EventType FROM MembershipLogs";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new MembershipLog
                        {
                            LogID = reader.GetInt32(0),
                            MemberID = reader.GetInt32(1),
                            EventDate = DateTime.Parse(reader.GetString(2)),
                            EventType = reader.GetString(3)
                        });
                    }
                }
            }

            return logs;
        }
    }
}
