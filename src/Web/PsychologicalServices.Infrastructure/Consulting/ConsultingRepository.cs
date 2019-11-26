using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Consulting;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Consulting
{
    public class ConsultingRepository : RepositoryBase, IConsultingRepository
    {
        private readonly IDate _date = null;

        public ConsultingRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ConsultingAgreementEntity>, IPathEdgeRootParser<ConsultingAgreementEntity>>
            ConsultingAgreementPath =
                (consultingAgreementPath => consultingAgreementPath
                    .Prefetch<UserEntity>(consultingAgreement => consultingAgreement.Psychologist)
                    .Prefetch<ReferralSourceEntity>(consultingAgreement => consultingAgreement.BillToReferralSource)
                    .Prefetch<CompanyEntity>(rawTestData => rawTestData.Company)
                );

        #endregion

        public ConsultingAgreement GetConsultingAgreement(int consultingAgreementId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ConsultingAgreement
                    .WithPath(ConsultingAgreementPath)
                    .Where(consultingAgreement => consultingAgreement.ConsultingAgreementId == consultingAgreementId)
                    .SingleOrDefault()
                    .ToConsultingAgreement();
            }
        }

        public IEnumerable<ConsultingAgreement> GetConsultingAgreements(ConsultingAgreementSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var consultingAgreements = meta.ConsultingAgreement
                    .WithPath(ConsultingAgreementPath);

                if (criteria.CompanyId.HasValue)
                {
                    consultingAgreements = consultingAgreements.Where(consultingAgreement => consultingAgreement.CompanyId == criteria.CompanyId);
                }

                return Execute<ConsultingAgreementEntity>(
                        (ILLBLGenProQuery)
                        consultingAgreements
                    )
                    .Select(consultingAgreement => consultingAgreement.ToConsultingAgreement())
                    .ToList();
            }
        }
    }
}
