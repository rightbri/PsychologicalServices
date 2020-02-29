using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Gose
{
    public interface IGoseService
    {
        IEnumerable<GoseAccidentTimeframe> GetAccidentTimeframes();

        IEnumerable<GoseFamilyAndFriendshipsDisruptionLevel> GetFamilyAndFriendshipDisruptionLevels();

        IEnumerable<GoseRespondentType> GetRespondentTypes();

        IEnumerable<GoseReturnToNormalLifeOutcomeFactor> GetReturnToNormalLifeOutcomeFactors();

        IEnumerable<GoseSocialAndLeisureRestrictionExtent> GetSocialAndLeisureRestrictionExtents();

        IEnumerable<GoseWorkRestrictionLevel> GetWorkRestrictionLevels();

        GoseInterview GetInterview(int assessmentId);

        SaveResult<GoseInterview> SaveInterview(GoseInterview interview);

        DeleteResult DeleteInterview(int id);
    }
}
