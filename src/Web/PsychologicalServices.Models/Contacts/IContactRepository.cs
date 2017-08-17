using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Contacts
{
    public interface IContactRepository
    {
        Contact GetContactById(int id);

        Contact GetContactByEmail(string email);

        ContactType GetContactType(int id);

        IEnumerable<Contact> GetContacts(ContactSearchCriteria criteria);

        IEnumerable<ContactType> GetContactTypes(bool? isActive = true);

        int SaveContact(Contact contact);

        int SaveContactType(ContactType contactType);
    }
}
