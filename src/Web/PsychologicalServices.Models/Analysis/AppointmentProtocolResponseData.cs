using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Models.Analysis
{
    public class AppointmentProtocolResponseData
    {
		public int PsychometristId { get; set; }
	
		public string PsychometristFirstName { get; set; }

		public string PsychometristLastName { get; set; }
	
		public int AppointmentId { get; set; }
	
		public int AssessmentId { get; set; }
	
		public DateTimeOffset AppointmentTime { get; set; }
	
		public int ClaimantId { get; set; }
	
		public string ClaimantFirstName { get; set; }
	
		public string ClaimantLastName { get; set; }
	
		public string Question { get; set; }
	
		public int? Response { get; set; }
	}
}
