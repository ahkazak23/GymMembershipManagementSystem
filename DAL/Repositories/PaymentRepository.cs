using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Models.Entities;

namespace DAL.Repositories
{
    public class PaymentRepository
    {
        /// <summary>
        /// Adds a new payment to the database.
        /// </summary>
        /// <param name="payment">Payment object containing payment details.</param>
        public void AddPayment(Payment payment)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "INSERT INTO Payments (MemberID, PaymentDate, Amount, Status, PaymentDescription) " +
                               "VALUES (@MemberID, @PaymentDate, @Amount, @Status, @PaymentDescription)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", payment.MemberID);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@Status", payment.Status);
                    command.Parameters.AddWithValue("@PaymentDescription", payment.PaymentDescription ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates the status of a payment.
        /// </summary>
        public void UpdatePaymentStatus(int paymentId, string status)
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "UPDATE Payments SET Status = @Status WHERE PaymentID = @PaymentID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    command.Parameters.AddWithValue("@Status", status);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all payments for a specific member.
        /// </summary>
        public List<Payment> GetPaymentsByMemberId(int memberId)
        {
            var payments = new List<Payment>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT PaymentID, MemberID, PaymentDate, Amount, Status, PaymentDescription FROM Payments WHERE MemberID = @MemberID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentID = reader.GetInt32(0),
                                MemberID = reader.GetInt32(1),
                                PaymentDate = DateTime.Parse(reader.GetString(2)),
                                Amount = Convert.ToDecimal(reader.GetDouble(3)),
                                Status = reader.GetString(4),
                                PaymentDescription = reader.IsDBNull(5) ? null : reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return payments;
        }

        /// <summary>
        /// Retrieves total revenue from all payments.
        /// </summary>
        public decimal GetTotalRevenue()
        {
            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT SUM(Amount) FROM Payments";

                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
        }
        public List<(string Month, decimal TotalRevenue)> GetMonthlyRevenue()
        {
            var monthlyRevenue = new List<(string Month, decimal TotalRevenue)>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = @"
            SELECT 
                strftime('%Y-%m', PaymentDate) AS Month,
                SUM(Amount) AS TotalRevenue
            FROM Payments
            GROUP BY strftime('%Y-%m', PaymentDate)
            ORDER BY strftime('%Y-%m', PaymentDate)";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader.GetString(0);
                        decimal totalRevenue = reader.GetDecimal(1);

                        monthlyRevenue.Add((month, totalRevenue));
                    }
                }
            }

            return monthlyRevenue;
        }


        /// <summary>
        /// Retrieves all overdue payments.
        /// </summary>
        public List<Payment> GetOverduePayments()
        {
            var overduePayments = new List<Payment>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT PaymentID, MemberID, PaymentDate, Amount, Status, PaymentDescription FROM Payments WHERE Status = 'Overdue'";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        overduePayments.Add(new Payment
                        {
                            PaymentID = reader.GetInt32(0),
                            MemberID = reader.GetInt32(1),
                            PaymentDate = DateTime.Parse(reader.GetString(2)),
                            Amount = Convert.ToDecimal(reader.GetDouble(3)),
                            Status = reader.GetString(4),
                            PaymentDescription = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }
                }
            }

            return overduePayments;
        }

        /// <summary>
        /// Retrieves payments made within a specific date range.
        /// </summary>
        public List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var payments = new List<Payment>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT PaymentID, MemberID, PaymentDate, Amount, Status, PaymentDescription FROM Payments " +
                               "WHERE PaymentDate BETWEEN @StartDate AND @EndDate";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentID = reader.GetInt32(0),
                                MemberID = reader.GetInt32(1),
                                PaymentDate = DateTime.Parse(reader.GetString(2)),
                                Amount = Convert.ToDecimal(reader.GetDouble(3)),
                                Status = reader.GetString(4),
                                PaymentDescription = reader.IsDBNull(5) ? null : reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return payments;
        }
    }
}
