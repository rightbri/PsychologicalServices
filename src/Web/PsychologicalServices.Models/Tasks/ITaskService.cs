using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Tasks
{
    public interface ITaskService
    {
        TaskStatus GetTaskStatus(int id);

        IEnumerable<TaskStatus> GetTaskStatuses(bool? isActive = true);

        SaveResult<Task> SaveTask(Task task);
    }
}
