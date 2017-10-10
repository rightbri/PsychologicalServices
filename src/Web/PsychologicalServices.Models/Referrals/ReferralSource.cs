﻿using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSource
    {
        public int ReferralSourceId { get; set; }

        public string Name { get; set; }

        public ReferralSourceType ReferralSourceType { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public bool IsNew()
        {
            return ReferralSourceId == 0;
        }
    }
}
