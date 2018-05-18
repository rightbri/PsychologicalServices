using PsychologicalServices.Models.Documents;
using System;
using System.IO;

namespace PsychologicalServices.Api.Models
{
    public class DocumentModel
    {
        public int DocumentId { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string OriginalName { get; set; }

        public Document ToDocument()
        {
            var data = HasFile ? Convert.FromBase64String(Data) : null;

            var name = HasFile ? $"{Path.GetFileNameWithoutExtension(Name)}{Path.GetExtension(OriginalName ?? Name)}" : Name;

            return new Document
            {
                DocumentId = DocumentId,
                Name = name,
                Data = data,
                Size = HasFile ? data.Length : 0,
            };
        }

        public bool HasFile
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Data);
            }
        }
    }
}