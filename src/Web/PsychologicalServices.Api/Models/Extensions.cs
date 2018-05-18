using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Documents;
using System;

namespace PsychologicalServices.Api.Models
{
    public static class Extensions
    {
        public static DocumentModel ToDocumentModel(this Document document)
        {
            return null != document
                ? new DocumentModel
                {
                    DocumentId = document.DocumentId,
                    Name = document.Name,
                    Data = null != document.Data ? Convert.ToBase64String(document.Data) : null,
                }
                : null;
        }

        public static SaveResult<DocumentModel> ToDocumentModelSaveResult(this SaveResult<Document> documentSaveResult)
        {
            var result = new SaveResult<DocumentModel>
            {
                ErrorDetails = documentSaveResult.ErrorDetails,
                IsError = documentSaveResult.IsError,
                IsSaved = documentSaveResult.IsSaved,
                Item = documentSaveResult.Item.ToDocumentModel(),
                ValidationResult = documentSaveResult.ValidationResult,
            };

            return result;
        }
    }
}