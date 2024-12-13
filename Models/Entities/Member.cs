using System;

namespace Models.Entities
{
    public class Member
    {
        public int MemberID { get; set; } // Primary key
        public string FirstName { get; set; } // Member's first name
        public string LastName { get; set; } // Member's last name
        public string Phone { get; set; } // Member's phone number
        public string Email { get; set; } // Member's email address
        public DateTime DateOfBirth { get; set; } // Member's birthdate
        public string MembershipType { get; set; } // e.g., Monthly, Annual
        public DateTime StartDate { get; set; } // Membership start date
        public DateTime EndDate { get; set; } // Membership end date
    }
}