using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface IHtmlToPdfService
    {
        byte[] GetPdf(string html, HtmlToPdfParameters parameters = null);
    }
}
