using System;

namespace Models.Entities
{
    public class MembershipLog
    {
        public int LogID { get; set; }
        public int MemberID { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; } // Renewed, Cancelled, Expired
    }
}