using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Common;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        private IAddressService _addressService = null;

        public AddressController(
            IAddressService addressService
        )
        {
            _addressService = addressService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Address))]
        public IHttpActionResult Get(int id)
        {
            var address = _addressService.GetAddress(id);

            return Ok(address);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Address>))]
        public IHttpActionResult Search(AddressSearchCriteria criteria)
        {
            var addresses = _addressService.SearchAddresses(criteria);

            return Ok(addresses);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Address>))]
        public IHttpActionResult Save(Address address)
        {
            var result = _addressService.SaveAddress(address);

            return Ok(result);
        }
    }
}
