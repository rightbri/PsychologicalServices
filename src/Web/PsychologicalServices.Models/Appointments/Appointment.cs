using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Tasks;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        //copied from Assessment
        public int CompanyId { get; set; }

        public bool PsychometristConfirmed { get; set; }

        public DateTime AppointmentTime { get; set; }

        public Address Location { get; set; }

        public User Psychometrist { get; set; }

        public User Psychologist { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public bool Deleted { get; set; }

        public IEnumerable<Task> AppointmentTasks { get; set; }

        public Assessment Assessment { get; set; }

        public bool IsNew()
        {
            return AppointmentId == 0;
        }
    }
}
