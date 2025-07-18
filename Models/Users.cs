using System.ComponentModel.DataAnnotations;

namespace TVBroadcastScheduler.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }  // Scheduler, Approver, Admin
    }
}
