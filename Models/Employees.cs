using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Batteries = new HashSet<Batteries>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordSentAt { get; set; }
        public DateTime? RememberCreatedAt { get; set; }
        public int SignInCount { get; set; }
        public DateTime? CurrentSignInAt { get; set; }
        public DateTime? LastSignInAt { get; set; }
        public string CurrentSignInIp { get; set; }
        public string LastSignInIp { get; set; }
        public string ConfirmationToken { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? ConfirmationSentAt { get; set; }
        public string UnconfirmedEmail { get; set; }
        public int FailedAttempts { get; set; }
        public string UnlockToken { get; set; }
        public DateTime? LockedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Firstname { get; set; }
        public string Function { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Batteries> Batteries { get; set; }
    }
}
