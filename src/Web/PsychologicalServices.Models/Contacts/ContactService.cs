using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository = null;
        private readonly IContactValidator _contactValidator = null;
        private readonly IContactTypeValidator _contactTypeValidator = null;
        private readonly ILog _log = null;

        public ContactService(
            IContactRepository contactRepository,
            IContactValidator contactValidator,
            IContactTypeValidator contactTypeValidator,
            ILog log
        )
        {
            _contactRepository = contactRepository;
            _contactValidator = contactValidator;
            _contactTypeValidator = contactTypeValidator;
            _log = log;
        }

        public Contact GetContactByEmail(string email)
        {
            var contact = _contactRepository.GetContactByEmail(email);

            return contact;
        }

        public Contact GetContactById(int id)
        {
            var contact = _contactRepository.GetContactById(id);

            return contact;
        }

        public ContactType GetContactType(int id)
        {
            var contactType = _contactRepository.GetContactType(id);

            return contactType;
        }

        public IEnumerable<Contact> GetContacts(ContactSearchCriteria criteria)
        {
            var contacts = _contactRepository.GetContacts(criteria);

            return contacts;
        }

        public IEnumerable<ContactType> GetContactTypes(bool? isActive = true)
        {
            var contactTypes = _contactRepository.GetContactTypes(isActive);

            return contactTypes;
        }
        
        public SaveResult<Contact> SaveContact(Contact contact)
        {
            var result = new SaveResult<Contact>();

            try
            {
                var validation = _contactValidator.Validate(contact);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _contactRepository.SaveContact(contact);

                    result.Item = _contactRepository.GetContactById(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveContact", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<ContactType> SaveContactType(ContactType contactType)
        {
            var result = new SaveResult<ContactType>();

            try
            {
                var validation = _contactTypeValidator.Validate(contactType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _contactRepository.SaveContactType(contactType);

                    result.Item = _contactRepository.GetContactType(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveContactType", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
