using log4net;
using System.Web.Http.ExceptionHandling;

namespace PsychologicalServices.Api.Infrastructure.Services
{
    public class Log4NetExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log = null;

        public Log4NetExceptionLogger(
            ILog log
        )
        {
            _log = log;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;

            _log.Error("Error", ex);
        }
    }
}