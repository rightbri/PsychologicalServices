using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Tasks;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Tasks
{
    public class TaskRepository : RepositoryBase, ITaskRepository
    {
        public TaskRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        public TaskStatus GetTaskStatus(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.TaskStatus
                    .Where(taskStatus => taskStatus.TaskStatusId == id)
                    .SingleOrDefault()
                    .ToTaskStatus();
            }
        }

        public IEnumerable<TaskStatus> GetTaskStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<TaskStatusEntity>(
                        (ILLBLGenProQuery)
                        meta.TaskStatus
                        .Where(taskStatus => isActive == null || taskStatus.IsActive == isActive.Value)
                    )
                    .Select(taskStatus => taskStatus.ToTaskStatus())
                    .ToList();
            }
        }

        public int SaveTask(Task task)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = task.IsNew();

                var entity = new TaskEntity
                {
                    IsNew = isNew,
                    TaskId = task.TaskId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.TaskTemplateId = task.TaskTemplateId;
                entity.TaskStatusId = task.TaskStatusId;

                adapter.SaveEntity(entity, false);

                return entity.TaskId;
            }
        }
    }
}
