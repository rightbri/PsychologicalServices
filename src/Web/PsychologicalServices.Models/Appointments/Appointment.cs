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

        public DateTimeOffset AppointmentTime { get; set; }

        public Address Location { get; set; }

        public User Psychometrist { get; set; }

        public User Psychologist { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public IEnumerable<Models.Attributes.AttributeValue> Attributes { get; set; }

        public Assessment Assessment { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public User CreateUser { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public User UpdateUser { get; set; }

        public bool IsCompletion { get; set; }

        public int? RoomRentalBillableAmount { get; set; }

        public bool IsNew()
        {
            return AppointmentId == 0;
        }
    }
}
