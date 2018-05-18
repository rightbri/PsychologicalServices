using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Documents
{
    public interface IDocumentRepository
    {
        bool DocumentExists(int documentId);

        Document GetDocument(int documentId);

        IEnumerable<Document> GetDocuments(DocumentSearchCriteria criteria);

        int SaveDocument(Document document);
    }
}
