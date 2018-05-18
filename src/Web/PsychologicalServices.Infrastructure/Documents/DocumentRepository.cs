using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Documents;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Documents
{
    public class DocumentRepository : RepositoryBase, IDocumentRepository
    {
        public DocumentRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public bool DocumentExists(int documentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var count = meta.Document
                    .Where(document => document.DocumentId == documentId)
                    .Count();

                return count == 1;
            }
        }

        public Document GetDocument(int documentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Document
                    .Where(document => document.DocumentId == documentId)
                    .SingleOrDefault()
                    .ToDocument();
            }
        }

        public IEnumerable<Document> GetDocuments(DocumentSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var documents = meta.Document.AsQueryable();

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        documents = documents.Where(document => document.Name.Contains(criteria.Name));
                    }
                }

                return Execute<DocumentEntity>(
                    (ILLBLGenProQuery)
                    documents
                    .ExcludeFields(document => document.Data)
                )
                .Select(document => document.ToDocument())
                .ToList();
            }
        }

        public int SaveDocument(Document document)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = document.IsNew();

                var entity = new DocumentEntity
                {
                    IsNew = isNew,
                    DocumentId = document.DocumentId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = document.Name;
                
                if (null != document.Data)
                {
                    entity.Data = document.Data;
                    entity.Size = document.Data.Length;
                }

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.DocumentId;
            }
        }
    }
}
