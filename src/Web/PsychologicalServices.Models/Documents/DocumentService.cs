using System;
using System.Collections.Generic;
using log4net;
using PsychologicalServices.Models.Common;

namespace PsychologicalServices.Models.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository = null;
        private readonly IDocumentValidator _documentValidator = null;
        private readonly ILog _log = null;

        public DocumentService(
            IDocumentRepository documentRepository,
            IDocumentValidator documentValidator,
            ILog log
        )
        {
            _documentRepository = documentRepository;
            _documentValidator = documentValidator;
            _log = log;
        }

        public Document GetDocument(int documentId)
        {
            var document = _documentRepository.GetDocument(documentId);

            return document;
        }

        public IEnumerable<Document> GetDocuments(DocumentSearchCriteria criteria)
        {
            var documents = _documentRepository.GetDocuments(criteria);

            return documents;
        }

        public SaveResult<Document> SaveDocument(Document document)
        {
            var result = new SaveResult<Document>();

            try
            {
                var validation = _documentValidator.Validate(document);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _documentRepository.SaveDocument(document);

                    result.Item = _documentRepository.GetDocument(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveDocument", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
