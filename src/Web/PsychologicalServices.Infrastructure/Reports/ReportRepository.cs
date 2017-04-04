using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Reports;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Reports
{
    public class ReportRepository : RepositoryBase, IReportRepository
    {
        public ReportRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        public ReportStatus GetReportStatus(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ReportStatus
                    .Where(reportStatus => reportStatus.ReportStatusId == id)
                    .SingleOrDefault()
                    .ToReportStatus();
            }
        }

        public ReportType GetReportType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ReportType
                    .Where(reportType => reportType.ReportTypeId == id)
                    .SingleOrDefault()
                    .ToReportType();
            }
        }

        public IEnumerable<ReportStatus> GetReportStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ReportStatusEntity>(
                        (ILLBLGenProQuery)
                        meta.ReportStatus
                        .Where(reportStatus => isActive == null || reportStatus.IsActive == isActive.Value)
                    )
                    .Select(reportStatus => reportStatus.ToReportStatus())
                    .ToList();
            }
        }

        public IEnumerable<ReportType> GetAssessmentTypeReportTypes(int assessmentTypeId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ReportTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.AssessmentTypeReportType
                        .Where(assessmentTypeReportType =>
                            assessmentTypeReportType.AssessmentTypeId == assessmentTypeId &&
                            assessmentTypeReportType.ReportType.IsActive == true
                        )
                    .Select(assessmentTypeReportType => assessmentTypeReportType.ReportType)
                    )
                    .Select(reportType => reportType.ToReportType())
                    .ToList();
            }
        }

        public IEnumerable<ReportType> GetReportTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ReportTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.ReportType
                        .Where(reportType => isActive == null || reportType.IsActive == isActive.Value)
                    )
                    .Select(reportType => reportType.ToReportType())
                    .ToList();
            }
        }

        public int SaveReportStatus(ReportStatus reportStatus)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = reportStatus.IsNew();

                var entity = new ReportStatusEntity
                {
                    IsNew = isNew,
                    ReportStatusId = reportStatus.ReportStatusId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = reportStatus.Name;
                entity.IsActive = reportStatus.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.ReportStatusId;
            }
        }

        public int SaveReportType(ReportType reportType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = reportType.IsNew();

                var entity = new ReportTypeEntity
                {
                    IsNew = isNew,
                    ReportTypeId = reportType.ReportTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = reportType.Name;
                entity.IsActive = reportType.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.ReportTypeId;
            }
        }
    }
}
