using PsychologicalServices.Api.Models;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/document")]
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService = null;

        public DocumentController(
            IDocumentService documentService
        )
        {
            _documentService = documentService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(DocumentModel))]
        public IHttpActionResult Get(int id)
        {
            var document = _documentService.GetDocument(id).ToDocumentModel();

            return Ok(document);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<DocumentModel>))]
        public IHttpActionResult Search(DocumentSearchCriteria criteria)
        {
            var documents = _documentService.GetDocuments(criteria)
                .Select(document => document.ToDocumentModel());

            return Ok(documents);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Document>))]
        public IHttpActionResult Save(DocumentModel document)
        {
            var result = _documentService.SaveDocument(document.ToDocument()).ToDocumentModelSaveResult();
            
            return Ok(result);
        }
    }
}
