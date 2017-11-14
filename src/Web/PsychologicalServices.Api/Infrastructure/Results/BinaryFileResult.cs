using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PsychologicalServices.Api.Infrastructure.Results
{
    public class BinaryFileResult : IHttpActionResult
    {
        private readonly byte[] _bytes;
        private readonly string _filename;

        public BinaryFileResult(
            byte[] bytes, 
            string filename
        )
        {
            _bytes = bytes;
            _filename = filename;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(_bytes)
                };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = _filename
                };

                return response;
            }, cancellationToken);
        }
    }
}