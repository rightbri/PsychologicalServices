using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.PhoneLogs;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/phonelog")]
    public class PhoneLogController : ApiController
    {
        private readonly IPhoneLogService _phoneLogService = null;

        public PhoneLogController(
            IPhoneLogService phoneLogService
        )
        {
            _phoneLogService = phoneLogService;
        }

        [RightAuthorize(StaticRights.ViewPhoneLog)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(PhoneLog))]
        public IHttpActionResult Get(int id)
        {
            var item = _phoneLogService.Get(id);

            return Ok(item);
        }

        [RightAuthorize(StaticRights.SearchPhoneLog)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<PhoneLog>))]
        public IHttpActionResult Search(PhoneLogSearchCriteria criteria)
        {
            var items = _phoneLogService.Get(criteria);

            return Ok(items);
        }

        [RightAuthorize(StaticRights.EditPhoneLog)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<PhoneLog>))]
        public IHttpActionResult Save(PhoneLog item)
        {
            var result = _phoneLogService.Save(item);

            return Ok(result);
        }

        [RightAuthorize(StaticRights.DeletePhoneLog)]
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(DeleteResult))]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _phoneLogService.Delete(id);

            return Ok(result);
        }
    }
}
