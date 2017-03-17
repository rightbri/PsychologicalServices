using System;

namespace PsychologicalServices.Models.Users
{
    public class UserSearchCriteria
    {
        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? CompanyId { get; set; }

        public int? RoleId { get; set; }

        public int? RightId { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? AvailableDate { get; set; }
    }
}
