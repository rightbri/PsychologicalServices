using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.TaskTemplates
{
    public interface ITaskTemplateRepository
    {
        TaskTemplate GetTaskTemplate(int id);

        IEnumerable<TaskTemplate> GetTaskTemplates(TaskTemplateSearchCriteria criteria);

        int SaveTaskTemplate(TaskTemplate taskTemplate);
    }
}
