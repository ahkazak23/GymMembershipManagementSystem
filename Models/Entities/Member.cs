using System;

namespace Models.Entities
{


    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } // Male, Female, Other
        public string MembershipType { get; set; } // Monthly, Quarterly, Yearly
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}