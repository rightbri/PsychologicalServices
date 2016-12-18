using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Invoices;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Invoices
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        public InvoiceRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<InvoiceAmount> GetInvoiceAmounts()
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceAmountEntity>(
                        (ILLBLGenProQuery)
                        meta.InvoiceAmount
                    )
                    .Select(invoiceAmount => invoiceAmount.ToInvoiceAmount())
                    .ToList();
            }
        }

        public void SaveInvoiceAmounts(IEnumerable<InvoiceAmount> invoiceAmounts)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var invoiceAmountCollection = new EntityCollection<InvoiceAmountEntity>();

                adapter.FetchEntityCollection(invoiceAmountCollection, null);

                var existingInvoiceAmounts = invoiceAmountCollection
                    .Where(invoiceAmountEntity => invoiceAmounts.Any(invoiceAmount =>
                        invoiceAmountEntity.ReferralSourceId == invoiceAmount.ReferralSourceId &&
                        invoiceAmountEntity.ReportTypeId == invoiceAmount.ReportTypeId
                        )
                    );

                foreach (var invoiceAmountEntity in existingInvoiceAmounts)
                {
                    var updatedInvoiceAmount = invoiceAmounts.Where(invoiceAmount =>
                        invoiceAmount.ReferralSourceId == invoiceAmountEntity.ReferralSourceId &&
                        invoiceAmount.ReportTypeId == invoiceAmountEntity.ReportTypeId)
                        .SingleOrDefault();

                    if (null != updatedInvoiceAmount)
                    {
                        invoiceAmountEntity.InvoiceAmount = updatedInvoiceAmount.Amount;
                    }
                }

                var newInvoiceAmounts = invoiceAmounts
                    .Where(invoiceAmount => !invoiceAmountCollection.Any(existingInvoiceAmount =>
                        existingInvoiceAmount.ReferralSourceId == invoiceAmount.ReferralSourceId &&
                        existingInvoiceAmount.ReportTypeId == invoiceAmount.ReportTypeId));

                invoiceAmountCollection.AddRange(
                    newInvoiceAmounts.Select(invoiceAmount =>
                    new InvoiceAmountEntity
                    {
                        IsNew = true,
                        ReferralSourceId = invoiceAmount.ReferralSourceId,
                        ReportTypeId = invoiceAmount.ReportTypeId,
                        InvoiceAmount = invoiceAmount.Amount,
                    })
                );

                adapter.SaveEntityCollection(invoiceAmountCollection);
            }
        }
    }
}
