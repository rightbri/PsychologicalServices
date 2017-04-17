using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentTime { get; set; }

        public Address Location { get; set; }

        public User Psychometrist { get; set; }

        public User Psychologist { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public IEnumerable<Models.Attributes.Attribute> Attributes { get; set; }

        public Assessment Assessment { get; set; }

        public bool IsNew()
        {
            return AppointmentId == 0;
        }
    }
}
