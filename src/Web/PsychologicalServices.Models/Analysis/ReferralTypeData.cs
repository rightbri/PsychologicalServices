using System;

namespace PsychologicalServices.Models.Analysis
{
    public class ReferralTypeData
    {
		public int AssessmentId { get; set; }

		public string ReferralType { get; set; }
	
		public DateTimeOffset AppointmentTime { get; set; }
		
		public int Year { get; set; }
	
		public int Month { get; set; }
	
		public bool IsPlaintiff { get; set; }
	
		public bool IsDefense { get; set; }
	}
}
