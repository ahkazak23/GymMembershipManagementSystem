using System;
using System.Collections.Generic;
using BLL.Managers;
using Models.Entities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MngBLL
    {
        private AdminManager _adminManager;
        private MemberManager _memberManager;
        private PaymentManager _paymentManager;
        private MembershipLogManager _logManager;

        [SetUp]
        public void SetUp()
        {
            // Initialize managers before each test
            _adminManager = new AdminManager();
            _memberManager = new MemberManager();
            _paymentManager = new PaymentManager();
            _logManager = new MembershipLogManager();

            // Clean database
            using (var connection = DAL.SQLiteConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Admins; DELETE FROM Members; DELETE FROM Payments; DELETE FROM MembershipLogs;";
                    command.ExecuteNonQuery();
                }
            }
        }

        [Test]
        public void RegisterAdmin_ShouldThrowExceptionForDuplicateUsername()
        {
            // Arrange
            string username = "duplicateAdmin";
            string password = "SecureP@ssword";
            _adminManager.RegisterAdmin(username, password);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _adminManager.RegisterAdmin(username, password),
                "RegisterAdmin should throw an exception for duplicate usernames.");
        }

        [Test]
        public void AddMember_ShouldThrowExceptionForInvalidPhone()
        {
            // Arrange
            var member = new Member
            {
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "123", // Invalid phone format
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                MembershipType = "Monthly",
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 2, 1)
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _memberManager.AddMember(member),
                "AddMember should throw an exception for invalid phone numbers.");
        }

        [Test]
        public void AddMember_ShouldThrowExceptionForFutureDateOfBirth()
        {
            // Arrange
            var member = new Member
            {
                FirstName = "Future",
                LastName = "Born",
                Phone = "1234567890",
                Email = "future.born@example.com",
                DateOfBirth = DateTime.Now.AddDays(1), // Future date
                MembershipType = "Monthly",
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 2, 1)
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _memberManager.AddMember(member),
                "AddMember should throw an exception for future dates of birth.");
        }

        [Test]
        public void AddPayment_ShouldThrowExceptionForInvalidStatus()
        {
            // Arrange
            var payment = new Payment
            {
                MemberID = 1,
                PaymentDate = new DateTime(2024, 12, 10),
                Amount = 100.00m,
                Status = "InvalidStatus" // Invalid status
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _paymentManager.AddPayment(payment),
                "AddPayment should throw an exception for invalid payment statuses.");
        }

        [Test]
        public void UpdatePaymentStatus_ShouldThrowExceptionForInvalidStatus()
        {
            // Arrange
            int paymentId = 1;
            string invalidStatus = "NotAValidStatus";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _paymentManager.UpdatePaymentStatus(paymentId, invalidStatus),
                "UpdatePaymentStatus should throw an exception for invalid statuses.");
        }

        [Test]
        public void GetPaymentsByMemberId_ShouldReturnEmptyForNonExistentMember()
        {
            // Arrange
            int nonExistentMemberId = 9999;

            // Act
            var payments = _paymentManager.GetPaymentsByMemberId(nonExistentMemberId);

            // Assert
            Assert.IsEmpty(payments, "GetPaymentsByMemberId should return an empty list for a non-existent member.");
        }

        [Test]
        public void AddLog_ShouldAddLogSuccessfully()
        {
            // Arrange
            var log = new MembershipLog
            {
                MemberID = 1,
                EventDate = DateTime.Now,
                EventType = "Renewed"
            };

            // Act
            _logManager.AddMembershipLog(log);

            // Assert
            var logs = _logManager.GetAllLogs();
            Assert.IsNotEmpty(logs, "AddLog should successfully add a new log.");
            Assert.AreEqual(1, logs.Count, "There should be exactly one log added.");
        }

        [Test]
        public void GetRecentLogs_ShouldReturnCorrectNumberOfLogs()
        {
            // Arrange
            for (int i = 0; i < 5; i++)
            {
                _logManager.AddMembershipLog(new MembershipLog
                {
                    MemberID = i + 1,
                    EventDate = DateTime.Now.AddDays(-i),
                    EventType = "Renewed"
                });
            }

            // Act
            var recentLogs = _logManager.GetRecentLogs(3);

            // Assert
            Assert.AreEqual(3, recentLogs.Count, "GetRecentLogs should return the correct number of logs.");
        }
    }
}
