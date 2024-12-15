using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Adds a new member to the system after validation.
        /// </summary>
        /// <param name="member">The member object containing member details.</param>
        public void AddMember(Member member)
        {
            ValidateMember(member);
            _memberRepository.AddMember(member);
        }

        /// <summary>
        /// Updates an existing member's information after validation.
        /// </summary>
        /// <param name="member">The member object containing updated details.</param>
        public void UpdateMember(Member member)
        {
            if (member.MemberID <= 0)
            {
                throw new ArgumentException("Invalid MemberID. MemberID must be greater than 0.");
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
        /// <returns>The member object with the specified ID, or null if not found.</returns>
        public Member GetMemberById(int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Invalid MemberID. MemberID must be greater than 0.");
            }

            return _memberRepository.GetMemberById(memberId);
        }

        /// <summary>
        /// Deletes a member from the system.
        /// </summary>
        /// <param name="memberId">The ID of the member to delete.</param>
        public void DeleteMember(int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Invalid MemberID. MemberID must be greater than 0.");
            }

            _memberRepository.DeleteMember(memberId);
        }

        /// <summary>
        /// Gets the total number of members in the system.
        /// </summary>
        /// <returns>Total member count.</returns>
        public int GetTotalMemberCount()
        {
            return _memberRepository.GetAllMembers().Count;
        }

        /// <summary>
        /// Gets the count of active members.
        /// </summary>
        /// <returns>Active member count.</returns>
        public int GetActiveMemberCount()
        {
            return _memberRepository.GetAllMembers().Count(m => m.IsActive);
        }

        /// <summary>
        /// Gets the count of expired memberships.
        /// </summary>
        /// <returns>Expired membership count.</returns>
        public int GetExpiredMemberCount()
        {
            return _memberRepository.GetAllMembers().Count(m => !m.IsActive);
        }
        public Dictionary<string, int> GetMembershipTypeDistribution()
        {
            return _memberRepository.GetMembershipTypeDistribution();
        }


        /// <summary>
        /// Validates the member object for required fields and logical consistency.
        /// </summary>
        /// <param name="member">The member object to validate.</param>
        private void ValidateMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(member.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (!string.IsNullOrEmpty(member.Phone) && !IsValidPhoneNumber(member.Phone))
            {
                throw new ArgumentException("Invalid phone number format. Ensure it includes only digits and optional '+' prefix.");
            }

            if (!string.IsNullOrEmpty(member.Email) && !IsValidEmail(member.Email))
            {
                throw new ArgumentException("Invalid email format. Ensure it is a valid email address.");
            }

            if (member.StartDate >= member.EndDate)
            {
                throw new ArgumentException("End date must be later than the start date.");
            }

            if (member.DateOfBirth.HasValue && member.DateOfBirth >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
        }
        
        /// <summary>
        /// Retrieves the age distribution of members.
        /// </summary>
        /// <returns>A dictionary where the key is the age range and the value is the member count.</returns>
        public Dictionary<string, int> GetAgeDistribution()
        {
            return _memberRepository.GetAgeDistribution();
        }

        /// <summary>
        /// Validates a phone number using a simple regex pattern.
        /// </summary>
        /// <param name="phone">The phone number to validate.</param>
        /// <returns>True if valid, false otherwise.</returns>
        private bool IsValidPhoneNumber(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+?[0-9]{7,15}$");
        }
        
        public List<Member> GetUpcomingExpirations(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("End date must be after the start date.");
            }

            return _memberRepository.GetMembersByExpirationDateRange(startDate, endDate);
        }
        public List<Member> GetRecentMembers(DateTime startDate)
        {
            return _memberRepository.GetMembersByStartDate(startDate, DateTime.Now);
        }
        public Dictionary<string, int> GetGenderDistribution()
        {
            var allMembers = GetAllMembers();
            var genderCounts = new Dictionary<string, int>
            {
                { "Male", allMembers.Count(m => m.Gender == "Male") },
                { "Female", allMembers.Count(m => m.Gender == "Female") },
                { "Other", allMembers.Count(m => m.Gender == "Other") }
            };
            return genderCounts;
        }



        /// <summary>
        /// Validates an email address using a simple regex pattern.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if valid, false otherwise.</returns>
        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
