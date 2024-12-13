using System;
using System.Collections.Generic;
using DAL.Repositories;
using Models.Entities;

namespace BLL.Managers
{
    public class MemberManager
    {
        private readonly MemberRepository _memberRepository;

        public MemberManager()
        {
            _memberRepository = new MemberRepository();
        }

        /// <summary>
        /// Adds a new member to the system.
        /// </summary>
        /// <param name="member">The member object containing member details.</param>
        /// <exception cref="ArgumentException">Thrown if required fields are missing or dates are invalid.</exception>
        public void AddMember(Member member)
        {
            ValidateMember(member);

            _memberRepository.AddMember(member);
        }

        /// <summary>
        /// Updates an existing member's information.
        /// </summary>
        /// <param name="member">The member object containing updated member details.</param>
        /// <exception cref="ArgumentException">Thrown if the MemberID is invalid or required fields are missing.</exception>
        public void UpdateMember(Member member)
        {
            if (member.MemberID <= 0)
            {
                throw new ArgumentException("Invalid MemberID.");
            }

            ValidateMember(member);

            _memberRepository.UpdateMember(member);
        }

        /// <summary>
        /// Retrieves a list of all members in the system.
        /// </summary>
        /// <returns>A list of all members.</returns>
        public List<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        /// <summary>
        /// Retrieves a specific member by their ID.
        /// </summary>
        /// <param name="memberId">The ID of the member to retrieve.</param>
        /// <returns>The member with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown if the MemberID is invalid.</exception>
        public Member GetMemberById(int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Invalid MemberID.");
            }

            return _memberRepository.GetMemberById(memberId);
        }

        /// <summary>
        /// Deletes a member from the system.
        /// </summary>
        /// <param name="memberId">The ID of the member to delete.</param>
        /// <exception cref="ArgumentException">Thrown if the MemberID is invalid.</exception>
        public void DeleteMember(int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Invalid MemberID.");
            }

            _memberRepository.DeleteMember(memberId);
        }

        /// <summary>
        /// Validates the details of a member.
        /// </summary>
        /// <param name="member">The member object to validate.</param>
        /// <exception cref="ArgumentException">Thrown if required fields are missing or dates are invalid.</exception>
        private void ValidateMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.FirstName))
            {
                throw new ArgumentException("First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(member.LastName))
            {
                throw new ArgumentException("Last name cannot be empty.");
            }

            if (!string.IsNullOrEmpty(member.Phone) && !IsValidPhoneNumber(member.Phone))
            {
                throw new ArgumentException("Invalid phone number format.");
            }

            if (!string.IsNullOrEmpty(member.Email) && !IsValidEmail(member.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (member.StartDate >= member.EndDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            if (member.DateOfBirth != null && member.DateOfBirth >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
        }

        /// <summary>
        /// Validates a phone number.
        /// </summary>
        /// <param name="phone">The phone number to validate.</param>
        /// <returns>True if the phone number is valid; otherwise, false.</returns>
        private bool IsValidPhoneNumber(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+?[0-9]{7,15}$");
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid; otherwise, false.</returns>
        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
