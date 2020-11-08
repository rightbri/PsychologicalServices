﻿using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public interface IAnalysisRepository
    {
        IEnumerable<ReferralTypeData> GetReferralTypeData(ReferralTypeDataSearchCriteria criteria);

        IEnumerable<BookingData> GetBookingData(BookingDataSearchCriteria criteria);

        IEnumerable<CancellationData> GetCancellationData(CancellationDataSearchCriteria criteria);

        IEnumerable<CompletionData> GetCompletionData(CompletionDataSearchCriteria criteria);

        IEnumerable<ArbitrationData> GetArbitrationData(ArbitrationDataSearchCriteria criteria);

        IEnumerable<AssessmentTypeCount> GetNumberOfCompletedAssessments(AssessmentTypeCountDataSearchCriteria criteria);

        CredibilityData GetCredibilityData(CredibilityDataSearchCriteria criteria);

        IEnumerable<NonAbCompletionData> GetNonAbCompletionData(NonAbCompletionDataSearchCriteria criteria);

        IEnumerable<ResearchConsentObtainedClaimantData> GetResearchConsentObtainedClaimantData(ResearchConsentObtainedClaimantDataSearchCriteria criteria);

        IEnumerable<AppointmentProtocolResponseData> GetAppointmentProtocolResponseData(AppointmentProtocolResponseDataSearchCriteria criteria);
    }
}
