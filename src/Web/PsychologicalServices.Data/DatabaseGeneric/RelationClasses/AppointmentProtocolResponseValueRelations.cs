﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using PsychologicalServices.Data;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: AppointmentProtocolResponseValue. </summary>
	public partial class AppointmentProtocolResponseValueRelations
	{
		/// <summary>CTor</summary>
		public AppointmentProtocolResponseValueRelations()
		{
		}

		/// <summary>Gets all relations of the AppointmentProtocolResponseValueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingAdvisedOfUnexpectedDelaysId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingAfterAssessmentNotificationId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingAllFormsCompletedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingAllPapersHaveClaimantInitialsAndDateId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingAskedWhichTestsShouldBeRemovedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingClaimantArrivalNotificationId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingCovidFormsCompletedBeforeEnteringRoomId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingErrorCheckedObservationsId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingOnTimeArrivalAndNotificationId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingRelevantObservationsDocumentedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingRespondedToQuestionsWithinRequiredTimeframeId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingScansUploadedNotificationId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingScoringDoubleCheckedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingSpareSetReplenishmentRequestSentId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingStapledItemsTogetherId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingTestedClaimantsEnglishReadingLevelId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingTimeAssessmentLabelCompletedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingTommSimsScoreNotificationId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingUploadedScanLegibilityVerifiedId);
			toReturn.Add(this.AppointmentProtocolResponseEntityUsingWillPersonallyDropOffPackageId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.AdvisedOfUnexpectedDelaysId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingAdvisedOfUnexpectedDelaysId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.AdvisedOfUnexpectedDelaysId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.AfterAssessmentNotificationId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingAfterAssessmentNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses1" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.AfterAssessmentNotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.AllFormsCompletedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingAllFormsCompletedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses2" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.AllFormsCompletedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.AllPapersHaveClaimantInitialsAndDateId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingAllPapersHaveClaimantInitialsAndDateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses3" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.AllPapersHaveClaimantInitialsAndDateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.AskedWhichTestsShouldBeRemovedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingAskedWhichTestsShouldBeRemovedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses4" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.AskedWhichTestsShouldBeRemovedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.ClaimantArrivalNotificationId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingClaimantArrivalNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses5" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.ClaimantArrivalNotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.CovidFormsCompletedBeforeEnteringRoomId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingCovidFormsCompletedBeforeEnteringRoomId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses6" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.CovidFormsCompletedBeforeEnteringRoomId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.ErrorCheckedObservationsId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingErrorCheckedObservationsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses7" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.ErrorCheckedObservationsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.OnTimeArrivalAndNotificationId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingOnTimeArrivalAndNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses8" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.OnTimeArrivalAndNotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.RelevantObservationsDocumentedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingRelevantObservationsDocumentedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses9" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.RelevantObservationsDocumentedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.RespondedToQuestionsWithinRequiredTimeframeId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingRespondedToQuestionsWithinRequiredTimeframeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses10" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.RespondedToQuestionsWithinRequiredTimeframeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.ScansUploadedNotificationId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingScansUploadedNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses11" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.ScansUploadedNotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.ScoringDoubleCheckedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingScoringDoubleCheckedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses12" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.ScoringDoubleCheckedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.SpareSetReplenishmentRequestSentId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingSpareSetReplenishmentRequestSentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses13" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.SpareSetReplenishmentRequestSentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.StapledItemsTogetherId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingStapledItemsTogetherId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses14" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.StapledItemsTogetherId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.TestedClaimantsEnglishReadingLevelId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingTestedClaimantsEnglishReadingLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses15" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.TestedClaimantsEnglishReadingLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.TimeAssessmentLabelCompletedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingTimeAssessmentLabelCompletedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses16" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.TimeAssessmentLabelCompletedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.TommSimsScoreNotificationId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingTommSimsScoreNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses17" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.TommSimsScoreNotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.UploadedScanLegibilityVerifiedId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingUploadedScanLegibilityVerifiedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses18" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.UploadedScanLegibilityVerifiedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentProtocolResponseValueEntity and AppointmentProtocolResponseEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentProtocolResponseValue.AppointmentProtocolResponseValueId - AppointmentProtocolResponse.WillPersonallyDropOffPackageId
		/// </summary>
		public virtual IEntityRelation AppointmentProtocolResponseEntityUsingWillPersonallyDropOffPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentProtocolResponses19" , true);
				relation.AddEntityFieldPair(AppointmentProtocolResponseValueFields.AppointmentProtocolResponseValueId, AppointmentProtocolResponseFields.WillPersonallyDropOffPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseValueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentProtocolResponseEntity", false);
				return relation;
			}
		}


		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAppointmentProtocolResponseValueRelations
	{
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingAdvisedOfUnexpectedDelaysIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingAdvisedOfUnexpectedDelaysId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingAfterAssessmentNotificationIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingAfterAssessmentNotificationId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingAllFormsCompletedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingAllFormsCompletedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingAllPapersHaveClaimantInitialsAndDateIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingAllPapersHaveClaimantInitialsAndDateId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingAskedWhichTestsShouldBeRemovedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingAskedWhichTestsShouldBeRemovedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingClaimantArrivalNotificationIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingClaimantArrivalNotificationId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingCovidFormsCompletedBeforeEnteringRoomIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingCovidFormsCompletedBeforeEnteringRoomId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingErrorCheckedObservationsIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingErrorCheckedObservationsId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingOnTimeArrivalAndNotificationIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingOnTimeArrivalAndNotificationId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingRelevantObservationsDocumentedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingRelevantObservationsDocumentedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingRespondedToQuestionsWithinRequiredTimeframeIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingRespondedToQuestionsWithinRequiredTimeframeId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingScansUploadedNotificationIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingScansUploadedNotificationId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingScoringDoubleCheckedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingScoringDoubleCheckedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingSpareSetReplenishmentRequestSentIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingSpareSetReplenishmentRequestSentId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingStapledItemsTogetherIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingStapledItemsTogetherId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingTestedClaimantsEnglishReadingLevelIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingTestedClaimantsEnglishReadingLevelId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingTimeAssessmentLabelCompletedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingTimeAssessmentLabelCompletedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingTommSimsScoreNotificationIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingTommSimsScoreNotificationId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingUploadedScanLegibilityVerifiedIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingUploadedScanLegibilityVerifiedId;
		internal static readonly IEntityRelation AppointmentProtocolResponseEntityUsingWillPersonallyDropOffPackageIdStatic = new AppointmentProtocolResponseValueRelations().AppointmentProtocolResponseEntityUsingWillPersonallyDropOffPackageId;

		/// <summary>CTor</summary>
		static StaticAppointmentProtocolResponseValueRelations()
		{
		}
	}
}