using System;

namespace Models.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; } // Primary key
        public int MemberID { get; set; } // Foreign key to Members
        public DateTime PaymentDate { get; set; } // Date of payment
        public double Amount { get; set; } // Payment amount
        public string Status { get; set; } // e.g., Paid, Overdue
    }
}