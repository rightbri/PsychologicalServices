using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.TaskTemplates;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.TaskTemplates
{
    public class TaskTemplateRepository : RepositoryBase, ITaskTemplateRepository
    {
        public TaskTemplateRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        public TaskTemplate GetTaskTemplate(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.TaskTemplate
                    .Where(taskTemplate => taskTemplate.TaskTemplateId == id)
                    .SingleOrDefault()
                    .ToTaskTemplate();
            }
        }

        public IEnumerable<TaskTemplate> GetTaskTemplates(TaskTemplateSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var taskTemplates = meta.TaskTemplate.AsQueryable();

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        taskTemplates = taskTemplates
                            .Where(taskTemplate => taskTemplate.Name == criteria.Name);
                    }

                    if (criteria.CompanyId.HasValue)
                    {
                        taskTemplates = taskTemplates
                            .Where(taskTemplate => taskTemplate.CompanyId == criteria.CompanyId.Value);
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        taskTemplates = taskTemplates
                            .Where(taskTemplate => taskTemplate.IsActive == criteria.IsActive);
                    }
                }

                return Execute<TaskTemplateEntity>(
                        (ILLBLGenProQuery)
                        taskTemplates
                    )
                    .Select(taskTemplate => taskTemplate.ToTaskTemplate())
                    .ToList();
            }
        }

        public int SaveTaskTemplate(TaskTemplate taskTemplate)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = taskTemplate.IsNew();

                var entity = new TaskTemplateEntity
                {
                    IsNew = isNew,
                    TaskTemplateId = taskTemplate.TaskTemplateId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = taskTemplate.Name;
                entity.CompanyId = taskTemplate.CompanyId;
                entity.IsActive = taskTemplate.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.TaskTemplateId;
            }
        }
    }
}
