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
                string query = "INSERT INTO Payments (MemberID, PaymentDate, Amount, Status) " +
                               "VALUES (@MemberID, @PaymentDate, @Amount, @Status)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", payment.MemberID);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@Status", payment.Status);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates the status of a payment.
        /// </summary>
        /// <param name="paymentId">ID of the payment to update.</param>
        /// <param name="status">New status for the payment.</param>
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
        /// <param name="memberId">ID of the member.</param>
        /// <returns>List of Payment objects.</returns>
        public List<Payment> GetPaymentsByMemberId(int memberId)
        {
            var payments = new List<Payment>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT PaymentID, MemberID, PaymentDate, Amount, Status FROM Payments WHERE MemberID = @MemberID";

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
                                Amount = reader.GetDouble(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return payments;
        }

        /// <summary>
        /// Retrieves all overdue payments from the database.
        /// </summary>
        /// <returns>List of overdue Payment objects.</returns>
        public List<Payment> GetOverduePayments()
        {
            var overduePayments = new List<Payment>();

            using (var connection = SQLiteConnectionFactory.CreateConnection())
            {
                string query = "SELECT PaymentID, MemberID, PaymentDate, Amount, Status FROM Payments WHERE Status = 'Overdue'";

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
                            Amount = reader.GetDouble(3),
                            Status = reader.GetString(4)
                        });
                    }
                }
            }

            return overduePayments;
        }
    }
}
