using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IHtmlToPdfService
    {
        byte[] GetPdf(string html, HtmlToPdfParameters parameters = null);
    }
}
