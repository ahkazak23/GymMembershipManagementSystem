using System;

namespace Models.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int MemberID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // Paid, Overdue
        public string PaymentDescription { get; set; } // Description of payment
    }
}