using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Documents;
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

        public Company Company { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public IEnumerable<Unavailability> Unavailability { get; set; }

        public IEnumerable<UserTravelFee> TravelFees { get; set; }

        public IEnumerable<Appointment> PsychometristAppointments { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? DateInactivated { get; set; }

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

        public bool IsAvailable(DateTimeOffset date)
        {
            return
                (
                    null == Unavailability ||
                    !Unavailability.Any(unavailability => unavailability.StartDate <= date && unavailability.EndDate >= date)
                ) &&
                (
                    IsActive ||
                    (DateInactivated.HasValue && DateInactivated.Value > date)
                );
        }
    }
}
