using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Employers
{
    public class EmployerSearchCriteria
    {
        public int? EmployerId { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> EmployerTypeIds { get; set; }

        public bool? IsActive { get; set; }
    }
}
