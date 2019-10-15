using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Companies;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Companies
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public CompanyRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<CompanyEntity>, IPathEdgeRootParser<CompanyEntity>>
            CompanyPath =
                (companyPath => companyPath
                    .Prefetch<AddressEntity>(company => company.Address)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<AddressEntity>(company => company.NewAppointmentLocation)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<UserEntity>(company => company.NewAppointmentPsychologist)
                    .Prefetch<UserEntity>(company => company.NewAppointmentPsychometrist)
                    .Prefetch<AppointmentStatusEntity>(company => company.NewAppointmentStatus)
                    .Prefetch<AssessmentTypeEntity>(company => company.NewAssessmentAssessmentType)
                        .SubPath(assessmentTypePath => assessmentTypePath
                            .Prefetch<AssessmentTypeReportTypeEntity>(assessmentType => assessmentType.AssessmentTypeReportTypes)
                                .SubPath(assessmentTypeReportTypePath => assessmentTypeReportTypePath
                                    .Prefetch<ReportTypeEntity>(assessmentTypeReportType => assessmentTypeReportType.ReportType)
                                )
                            .Prefetch<AssessmentTypeAttributeTypeEntity>(assessmentType => assessmentType.AssessmentTypeAttributeTypes)
                                .SubPath(assessmentTypeAttributeTypePath => assessmentTypeAttributeTypePath
                                    .Prefetch<AttributeTypeEntity>(assessmentTypeAttributeType => assessmentTypeAttributeType.AttributeType)
                                )
                        )
                    .Prefetch<ReportStatusEntity>(company => company.NewAssessmentReportStatus)
                );

        #endregion

        public Company GetCompany(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Company
                    .WithPath(CompanyPath)
                    .Where(company => company.CompanyId == id)
                    .SingleOrDefault()
                    .ToCompany();
            }
        }

        public IEnumerable<Company> GetCompanies(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<CompanyEntity>(
                        (ILLBLGenProQuery)
                        meta.Company
                        .Where(company => isActive == null || company.IsActive == isActive)
                    )
                    .Select(company => company.ToCompany())
                    .ToList();
            }
        }
        
        public int SaveCompany(Company company)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = company.IsNew();

                var entity = new CompanyEntity
                {
                    IsNew = isNew,
                    CompanyId = company.CompanyId
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = company.Name;
                entity.IsActive = company.IsActive;
                entity.AddressId = company.Address.AddressId;
                entity.Phone = company.Phone;
                entity.Fax = company.Fax;
                entity.Email = company.Email;
                entity.ReplyToEmail = company.ReplyToEmail;
                entity.AccountingEmail = company.AccountingEmail;
                entity.TaxId = company.TaxId;
                entity.Timezone = company.Timezone;
                entity.NewAppointmentTime = company.NewAppointmentTime.Ticks;
                entity.NewAppointmentLocationId = null != company.NewAppointmentLocation ? company.NewAppointmentLocation.AddressId : (int?)null;
                entity.NewAppointmentPsychologistId = null != company.NewAppointmentPsychologist ? company.NewAppointmentPsychologist.UserId : (int?)null;
                entity.NewAppointmentPsychometristId = null != company.NewAppointmentPsychometrist ? company.NewAppointmentPsychometrist.UserId : (int?)null;
                entity.NewAppointmentStatusId = null != company.NewAppointmentStatus ? company.NewAppointmentStatus.AppointmentStatusId : (int?)null;
                entity.NewAssessmentAssessmentTypeId = null != company.NewAssessmentAssessmentType ? company.NewAssessmentAssessmentType.AssessmentTypeId : (int?)null;
                entity.NewAssessmentReportStatusId = null != company.NewAssessmentReportStatus ? company.NewAssessmentReportStatus.ReportStatusId : (int?)null;
                entity.NewAssessmentSummaryNoteText = null != company.NewAssessmentSummary ? company.NewAssessmentSummary.NoteText : null;

                adapter.SaveEntity(entity);

                return entity.CompanyId;
            }
        }
    }
}
