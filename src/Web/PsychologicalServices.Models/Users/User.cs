using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public IEnumerable<Unavailability> Unavailability { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return UserId == 0;
        }

        public bool HasRight(StaticRights right)
        {
            return HasRight(right.ToString());
        }

        public bool HasRight(string rightName)
        {
            return null != Roles &&
                Roles.Any(role =>
                    null != role.Rights &&
                    role.Rights.Any(right =>
                        right.Name.Equals(rightName, StringComparison.OrdinalIgnoreCase)
                    )
                );
        }

        public bool IsAvailable(DateTime date)
        {
            return null != Unavailability
                ? !Unavailability.Any(unavailability => unavailability.StartDate <= date && unavailability.EndDate >= date)
                : true;
        }
    }
}
