using System;
using System.Linq;
using DAL.Repositories; // Replace with your actual DAL namespace
using Models.Entities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RepsDAL
    {
        private AdminRepository _adminRepository;
        private MemberRepository _memberRepository;
        private PaymentRepository _paymentRepository;

        [SetUp]
        public void SetUp()
        {
            // Initialize repositories before each test
            _adminRepository = new AdminRepository();
            _memberRepository = new MemberRepository();
            _paymentRepository = new PaymentRepository();
        }

        [Test]
        public void AddAdmin_ShouldAddNewAdmin()
        {
            // Arrange
            var admin = new Admin
            {
                Username = "FangYuan",
                PasswordHash = "123"
            };

            // Act
            _adminRepository.AddAdmin(admin);
            bool exists = _adminRepository.AdminExists(admin.Username);

            // Assert
            Assert.IsTrue(exists, "Admin should exist after being added.");
        }

        [Test]
        public void ValidateAdmin_ShouldReturnTrueForValidCredentials()
        {
            // Arrange
            var admin = new Admin
            {
                Username = "admin3",
                PasswordHash = "AnotherP@ssword123"
            };
            _adminRepository.AddAdmin(admin);

            // Act
            bool isValid = _adminRepository.ValidateAdmin(admin.Username, admin.PasswordHash);

            // Assert
            Assert.IsTrue(isValid, "ValidateAdmin should return true for correct credentials.");
        }

        [Test]
        public void AddMember_ShouldAddNewMember()
        {
            // Arrange
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Phone = "1234567890",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1985, 5, 20),
                MembershipType = "Monthly",
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 2, 1)
            };

            // Act
            _memberRepository.AddMember(member);
            var members = _memberRepository.GetAllMembers();

            // Assert
            Assert.IsTrue(members.Any(m => m.FirstName == member.FirstName && m.LastName == member.LastName),
                "The added member should exist in the list.");
        }

        [Test]
        public void AddPayment_ShouldAddNewPayment()
        {
            // Arrange
            int memberId = 1; // Ensure a member with this ID exists
            var payment = new Payment
            {
                MemberID = memberId,
                PaymentDate = new DateTime(2024, 12, 10),
                Amount = 200.00,
                Status = "Paid"
            };

            // Act
            _paymentRepository.AddPayment(payment);
            var payments = _paymentRepository.GetPaymentsByMemberId(memberId);

            // Assert
            Assert.IsTrue(payments.Any(p => p.PaymentDate == payment.PaymentDate && p.Amount == payment.Amount && p.Status == payment.Status),
                "The added payment should exist in the list.");
        }
    }
}
