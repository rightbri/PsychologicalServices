using System;

namespace PsychologicalServices.Models.Contacts
{
    public class ContactType
    {
        public const int Lawyer = 1;

        public int ContactTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ContactTypeId == 0;
        }
    }
}
