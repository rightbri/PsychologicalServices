using System;

namespace PsychologicalServices.Models.Tasks
{
    public class TaskStatus
    {
        public int TaskStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return TaskStatusId == 0;
        }
    }
}
