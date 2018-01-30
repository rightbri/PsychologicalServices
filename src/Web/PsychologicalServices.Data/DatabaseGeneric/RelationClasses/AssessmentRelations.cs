///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
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
	/// <summary>Implements the static Relations variant for the entity: Assessment. </summary>
	public partial class AssessmentRelations
	{
		/// <summary>CTor</summary>
		public AssessmentRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentEntityUsingAssessmentId);
			toReturn.Add(this.ArbitrationEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentAttributeEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentClaimEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentColorEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentMedRehabEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentNoteEntityUsingAssessmentId);
			toReturn.Add(this.AssessmentReportEntityUsingAssessmentId);

			toReturn.Add(this.AssessmentTypeEntityUsingAssessmentTypeId);
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			toReturn.Add(this.CredibilityEntityUsingPsychologicalCredibilityId);
			toReturn.Add(this.CredibilityEntityUsingNeurocognitiveCredibilityId);
			toReturn.Add(this.DiagnosisFoundResponseEntityUsingDiagnosisFoundReponseId);
			toReturn.Add(this.NoteEntityUsingSummaryNoteId);
			toReturn.Add(this.ReferralSourceEntityUsingReferralSourceId);
			toReturn.Add(this.ReferralTypeEntityUsingReferralTypeId);
			toReturn.Add(this.ReportStatusEntityUsingReportStatusId);
			toReturn.Add(this.UserEntityUsingUpdateUserId);
			toReturn.Add(this.UserEntityUsingCreateUserId);
			toReturn.Add(this.UserEntityUsingNotesWriterId);
			toReturn.Add(this.UserEntityUsingDocListWriterId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - Appointment.AssessmentId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Appointments" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AppointmentFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and ArbitrationEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - Arbitration.AssessmentId
		/// </summary>
		public virtual IEntityRelation ArbitrationEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Arbitrations" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, ArbitrationFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentAttribute.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentAttributeEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentAttributes" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentAttributeFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentAttributeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentClaimEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentClaim.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentClaimEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentClaims" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentClaimFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentClaimEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentColorEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentColor.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentColorEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentColors" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentColorFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentColorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentMedRehabEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentMedRehab.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentMedRehabEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentMedRehabs" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentMedRehabFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentMedRehabEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentNote.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentNoteEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentNotes" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentNoteFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentReportEntity over the 1:n relation they have, using the relation between the fields:
		/// Assessment.AssessmentId - AssessmentReport.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentReportEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentReports" , true);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentReportFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and AssessmentTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.AssessmentTypeId - AssessmentType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AssessmentType", false);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, AssessmentFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, AssessmentFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and CredibilityEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.PsychologicalCredibilityId - Credibility.CredibilityId
		/// </summary>
		public virtual IEntityRelation CredibilityEntityUsingPsychologicalCredibilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PsychologicalCredibility", false);
				relation.AddEntityFieldPair(CredibilityFields.CredibilityId, AssessmentFields.PsychologicalCredibilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CredibilityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and CredibilityEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.NeurocognitiveCredibilityId - Credibility.CredibilityId
		/// </summary>
		public virtual IEntityRelation CredibilityEntityUsingNeurocognitiveCredibilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NeurocognitiveCredibility", false);
				relation.AddEntityFieldPair(CredibilityFields.CredibilityId, AssessmentFields.NeurocognitiveCredibilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CredibilityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and DiagnosisFoundResponseEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.DiagnosisFoundReponseId - DiagnosisFoundResponse.DiagnosisFoundResponseId
		/// </summary>
		public virtual IEntityRelation DiagnosisFoundResponseEntityUsingDiagnosisFoundReponseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DiagnosisFoundResponse", false);
				relation.AddEntityFieldPair(DiagnosisFoundResponseFields.DiagnosisFoundResponseId, AssessmentFields.DiagnosisFoundReponseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DiagnosisFoundResponseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and NoteEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.SummaryNoteId - Note.NoteId
		/// </summary>
		public virtual IEntityRelation NoteEntityUsingSummaryNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Summary", false);
				relation.AddEntityFieldPair(NoteFields.NoteId, AssessmentFields.SummaryNoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and ReferralSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.ReferralSourceId - ReferralSource.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralSource", false);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, AssessmentFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and ReferralTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.ReferralTypeId - ReferralType.ReferralTypeId
		/// </summary>
		public virtual IEntityRelation ReferralTypeEntityUsingReferralTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralType", false);
				relation.AddEntityFieldPair(ReferralTypeFields.ReferralTypeId, AssessmentFields.ReferralTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and ReportStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.ReportStatusId - ReportStatus.ReportStatusId
		/// </summary>
		public virtual IEntityRelation ReportStatusEntityUsingReportStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReportStatus", false);
				relation.AddEntityFieldPair(ReportStatusFields.ReportStatusId, AssessmentFields.ReportStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.UpdateUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUpdateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UpdateUser", false);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.UpdateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.CreateUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingCreateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CreateUser", false);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.CreateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.NotesWriterId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingNotesWriterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotesWriter", false);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.NotesWriterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Assessment.DocListWriterId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingDocListWriterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DocListWriter", false);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.DocListWriterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", true);
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
}
