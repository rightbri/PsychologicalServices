using System;

namespace PsychologicalServices.Models.Employers
{
    public class Employer
    {
        public int EmployerId { get; set; }

        public string Name { get; set; }

        public EmployerType EmployerType { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return EmployerId == 0;
        }
    }
}
