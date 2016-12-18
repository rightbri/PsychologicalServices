using System;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressNotFoundException : Exception
    {
        private const string MessageFormat = "Address {0} was not found";

        public AddressNotFoundException(int addressId)
            : base(string.Format(MessageFormat, addressId))
        {
        }
    }
}
