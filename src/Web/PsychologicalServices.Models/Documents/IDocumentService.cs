using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Documents
{
    public interface IDocumentService
    {
        Document GetDocument(int documentId);

        IEnumerable<Document> GetDocuments(DocumentSearchCriteria criteria);

        SaveResult<Document> SaveDocument(Document document);
    }
}
