using System;

namespace PsychologicalServices.Models.Documents
{
    public class Document
    {
        public int DocumentId { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public byte[] Data { get; set; }

        public bool IsNew()
        {
            return DocumentId == 0;
        }
    }
}
