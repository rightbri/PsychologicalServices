using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Contacts;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/contacttype")]
    public class ContactTypeController : ApiController
    {
        private readonly IContactService _contactService = null;

        public ContactTypeController(
            IContactService contactService
        )
        {
            _contactService = contactService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult Get(int id)
        {
            var contactType = _contactService.GetContactType(id);

            return Ok(contactType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ContactType>))]
        public IHttpActionResult Get()
        {
            var contactTypes = _contactService.GetContactTypes();

            return Ok(contactTypes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ContactType>))]
        public IHttpActionResult Save(ContactType contactType)
        {
            var result = _contactService.SaveContactType(contactType);

            return Ok(result);
        }
    }
}
