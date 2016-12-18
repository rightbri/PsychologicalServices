using PsychologicalServices.Models.Companies;
using System;

namespace PsychologicalServices.Models.TaskTemplates
{
    public class TaskTemplate
    {
        public int TaskTemplateId { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public bool IsActive { get; set; }

        public Company Company { get; set; }

        public bool IsNew()
        {
            return TaskTemplateId == 0;
        }
    }
}
