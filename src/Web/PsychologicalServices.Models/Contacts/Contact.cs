using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Employers;

namespace PsychologicalServices.Models.Contacts
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public ContactType ContactType { get; set; }

        public Employer Employer { get; set; }

        public Address Address { get; set; }
        
        public bool IsNew()
        {
            return ContactId == 0;
        }
    }
}
