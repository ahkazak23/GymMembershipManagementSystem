using System;
using System.Collections.Generic;
using BLL.Managers; // Replace with your actual BLL namespace
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

        [SetUp]
        public void SetUp()
        {
            // Initialize managers before each test
            _adminManager = new AdminManager();
            _memberManager = new MemberManager();
            _paymentManager = new PaymentManager();

            // Clean database (optional, depending on setup)
            // Ensure no data from previous tests interferes with the current test
            using (var connection = DAL.SQLiteConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Admins; DELETE FROM Members; DELETE FROM Payments;";
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
                Amount = 100.00,
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
    }
}
