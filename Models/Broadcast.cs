﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TVBroadcastScheduler.Models
{
    public class Broadcast
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = "Pending";

        public string? CreatedBy { get; set; }

        public string? ApprovalComment { get; set; }  // Nullable


        public string? Category { get; set; }

        public string? Channel { get; set; }
    }
}