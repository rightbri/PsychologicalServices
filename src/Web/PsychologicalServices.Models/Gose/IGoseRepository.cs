using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Gose
{
    public interface IGoseRepository
    {
        IEnumerable<GoseAccidentTimeframe> GetAccidentTimeframes();

        IEnumerable<GoseFamilyAndFriendshipsDisruptionLevel> GetFamilyAndFriendshipDisruptionLevels();

        IEnumerable<GoseRespondentType> GetRespondentTypes();

        IEnumerable<GoseReturnToNormalLifeOutcomeFactor> GetReturnToNormalLifeOutcomeFactors();

        IEnumerable<GoseSocialAndLeisureRestrictionExtent> GetSocialAndLeisureRestrictionExtents();

        IEnumerable<GoseWorkRestrictionLevel> GetWorkRestrictionLevels();

        GoseInterview GetInterview(int assessmentId);

        int SaveInterview(GoseInterview interview);

        bool DeleteInterview(int id);
    }
}
