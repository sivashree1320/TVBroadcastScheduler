using System;
using System.ComponentModel.DataAnnotations;

namespace TVBroadcastScheduler.Models
{
    public class Broadcast
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // Status: Pending, Approved, Rejected
        public string Status { get; set; } = "Pending";

        // Who created it
        public string CreatedBy { get; set; }

        // Comments from approver (if any)
        public string ApprovalComment { get; set; }
    }
}
