using PsychologicalServices.Models.Attributes;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/attribute")]
    public class AttributeController : ApiController
    {
        private IAttributeService _attributeService = null;

        public AttributeController(
            IAttributeService attributeService
        )
        {
            _attributeService = attributeService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(PsychologicalServices.Models.Attributes.Attribute))]
        public IHttpActionResult Get(int id)
        {
            var attribute = _attributeService.GetAttribute(id);

            return Ok(attribute);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<PsychologicalServices.Models.Attributes.Attribute>))]
        public IHttpActionResult Search(AttributeSearchCriteria criteria)
        {
            var attributes = _attributeService.SearchAttributes(criteria);

            return Ok(attributes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<PsychologicalServices.Models.Attributes.Attribute>))]
        public IHttpActionResult Save(PsychologicalServices.Models.Attributes.Attribute attribute)
        {
            var result = _attributeService.SaveAttribute(attribute);

            return Ok(result);
        }
    }
}
