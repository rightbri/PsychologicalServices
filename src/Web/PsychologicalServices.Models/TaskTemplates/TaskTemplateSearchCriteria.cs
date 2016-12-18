using System;

namespace PsychologicalServices.Models.TaskTemplates
{
    public class TaskTemplateSearchCriteria
    {
        public string Name { get; set; }

        public int? CompanyId { get; set; }

        public bool? IsActive { get; set; }
    }
}
