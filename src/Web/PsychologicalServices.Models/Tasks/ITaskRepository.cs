using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Tasks
{
    public interface ITaskRepository
    {
        TaskStatus GetTaskStatus(int id);

        IEnumerable<TaskStatus> GetTaskStatuses(bool? isActive = true);

        int SaveTask(Task task);
    }
}
