using System;

namespace PsychologicalServices.Models.Common
{
    public class DeleteResult
    {
        public bool IsDeleted { get; set; }

        public bool IsError { get; set; }

        public string ErrorDetails { get; set; }
    }
}
