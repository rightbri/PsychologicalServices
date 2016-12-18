using PsychologicalServices.Models.TaskTemplates;
using System;

namespace PsychologicalServices.Models.Tasks
{
    public class Task
    {
        public int TaskId { get; set; }

        public int TaskTemplateId { get; set; }

        public int TaskStatusId { get; set; }
        
        public TaskTemplate TaskTemplate { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public bool IsNew()
        {
            return TaskId == 0;
        }
    }
}
