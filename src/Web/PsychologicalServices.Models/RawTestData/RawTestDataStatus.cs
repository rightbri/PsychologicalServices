using System;

namespace PsychologicalServices.Models.RawTestData
{
    public class RawTestDataStatus
    {
        public int RawTestDataStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool CanInvoice { get; set; }
    }
}
