using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Contacts;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService = null;

        public ContactController(
            IContactService contactService
        )
        {
            _contactService = contactService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult Get(int id)
        {
            var contact = _contactService.GetContactById(id);

            return Ok(contact);
        }
        
        [Route("byEmail")]
        [HttpPost]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult Post([FromBody]string email)
        {
            var contact = _contactService.GetContactByEmail(email);

            return Ok(contact);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Contact>))]
        public IHttpActionResult Post(ContactSearchCriteria criteria)
        {
            var contacts = _contactService.GetContacts(criteria);

            return Ok(contacts);
        }
        
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Contact>))]
        public IHttpActionResult Save(Contact contact)
        {
            var result = _contactService.SaveContact(contact);

            return Ok(result);
        }
    }
}
