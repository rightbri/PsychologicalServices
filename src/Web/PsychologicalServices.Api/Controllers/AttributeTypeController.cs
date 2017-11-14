using PsychologicalServices.Models.Attributes;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/attributetype")]
    public class AttributeTypeController : ApiController
    {
        private readonly IAttributeService _attributeService = null;

        public AttributeTypeController(
            IAttributeService attributeService
        )
        {
            _attributeService = attributeService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AttributeType>))]
        public IHttpActionResult Get()
        {
            var attributeTypes = _attributeService.GetAttributeTypes();

            return Ok(attributeTypes);
        }
    }
}
