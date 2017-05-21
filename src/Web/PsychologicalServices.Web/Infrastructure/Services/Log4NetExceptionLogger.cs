using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace PsychologicalServices.Web.Infrastructure.Services
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