using PsychologicalServices.Models.Addresses;
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
    [RoutePrefix("api/addresstype")]
    public class AddressTypeController : ApiController
    {
        private readonly IAddressService _addressService = null;

        public AddressTypeController(
            IAddressService addressService
        )
        {
            _addressService = addressService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AddressType>))]
        public IHttpActionResult Get()
        {
            var addressTypes = _addressService.GetAddressTypes();

            return Ok(addressTypes);
        }
    }
}
