using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository = null;

        public TaskService(
            ITaskRepository taskRepository
        )
        {
            _taskRepository = taskRepository;
        }

        public TaskStatus GetTaskStatus(int id)
        {
            var taskStatus = _taskRepository.GetTaskStatus(id);

            return taskStatus;
        }

        public IEnumerable<TaskStatus> GetTaskStatuses(bool? isActive = true)
        {
            var taskStatuses = _taskRepository.GetTaskStatuses(isActive);

            return taskStatuses;
        }

        public SaveResult<Task> SaveTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
