using System;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return AddressTypeId == 0;
        }
    }
}
