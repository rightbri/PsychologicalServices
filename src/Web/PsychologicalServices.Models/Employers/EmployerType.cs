using System;

namespace PsychologicalServices.Models.Employers
{
    public class EmployerType
    {
        public int EmployerTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return EmployerTypeId == 0;
        }
    }
}
