using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Contacts
{
    public interface IContactService
    {
        Contact GetContactByEmail(string email);

        Contact GetContactById(int id);

        ContactType GetContactType(int id);

        IEnumerable<Contact> GetContacts(ContactSearchCriteria criteria);

        IEnumerable<ContactType> GetContactTypes(bool? isActive = true);
        
        SaveResult<Contact> SaveContact(Contact contact);

        SaveResult<ContactType> SaveContactType(ContactType contactType);
    }
}
