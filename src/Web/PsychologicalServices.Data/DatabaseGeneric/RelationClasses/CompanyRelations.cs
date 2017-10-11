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
	/// <summary>Implements the static Relations variant for the entity: Company. </summary>
	public partial class CompanyRelations
	{
		/// <summary>CTor</summary>
		public CompanyRelations()
		{
		}

		/// <summary>Gets all relations of the CompanyEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentStatusInvoiceRateEntityUsingCompanyId);
			toReturn.Add(this.AssessmentEntityUsingCompanyId);
			toReturn.Add(this.AssessmentTypeInvoiceAmountEntityUsingCompanyId);
			toReturn.Add(this.CalendarNoteEntityUsingCompanyId);
			toReturn.Add(this.CompanyAttributeEntityUsingCompanyId);
			toReturn.Add(this.IssueInDisputeInvoiceAmountEntityUsingCompanyId);
			toReturn.Add(this.PsychometristInvoiceAmountEntityUsingCompanyId);
			toReturn.Add(this.ReferralSourceInvoiceConfigurationEntityUsingCompanyId);
			toReturn.Add(this.UserEntityUsingCompanyId);

			toReturn.Add(this.AddressEntityUsingNewAppointmentLocationId);
			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.AppointmentStatusEntityUsingNewAppointmentStatusId);
			toReturn.Add(this.AssessmentTypeEntityUsingNewAssessmentAssessmentTypeId);
			toReturn.Add(this.ReportStatusEntityUsingNewAssessmentReportStatusId);
			toReturn.Add(this.UserEntityUsingNewAppointmentPsychometristId);
			toReturn.Add(this.UserEntityUsingNewAppointmentPsychologistId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AppointmentStatusInvoiceRateEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - AppointmentStatusInvoiceRate.CompanyId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusInvoiceRateEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentStatusInvoiceRates" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, AppointmentStatusInvoiceRateFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusInvoiceRateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - Assessment.CompanyId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Assessments" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, AssessmentFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AssessmentTypeInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - AssessmentTypeInvoiceAmount.CompanyId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeInvoiceAmountEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentTypeInvoiceAmounts" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, AssessmentTypeInvoiceAmountFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and CalendarNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - CalendarNote.CompanyId
		/// </summary>
		public virtual IEntityRelation CalendarNoteEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, CalendarNoteFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalendarNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and CompanyAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - CompanyAttribute.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyAttributeEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CompanyAttributes" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, CompanyAttributeFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyAttributeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and IssueInDisputeInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - IssueInDisputeInvoiceAmount.CompanyId
		/// </summary>
		public virtual IEntityRelation IssueInDisputeInvoiceAmountEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IssueInDisputeInvoiceAmounts" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, IssueInDisputeInvoiceAmountFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and PsychometristInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - PsychometristInvoiceAmount.CompanyId
		/// </summary>
		public virtual IEntityRelation PsychometristInvoiceAmountEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PsychometristInvoiceAmounts" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, PsychometristInvoiceAmountFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and ReferralSourceInvoiceConfigurationEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - ReferralSourceInvoiceConfiguration.CompanyId
		/// </summary>
		public virtual IEntityRelation ReferralSourceInvoiceConfigurationEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralSourceInvoiceConfigurations" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, ReferralSourceInvoiceConfigurationFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceInvoiceConfigurationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - User.CompanyId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Users" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, UserFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAppointmentLocationId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingNewAppointmentLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAppointmentLocation", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, CompanyFields.NewAppointmentLocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, CompanyFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AppointmentStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAppointmentStatusId - AppointmentStatus.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusEntityUsingNewAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAppointmentStatus", false);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, CompanyFields.NewAppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AssessmentTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAssessmentAssessmentTypeId - AssessmentType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeEntityUsingNewAssessmentAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAssessmentAssessmentType", false);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, CompanyFields.NewAssessmentAssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and ReportStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAssessmentReportStatusId - ReportStatus.ReportStatusId
		/// </summary>
		public virtual IEntityRelation ReportStatusEntityUsingNewAssessmentReportStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAssessmentReportStatus", false);
				relation.AddEntityFieldPair(ReportStatusFields.ReportStatusId, CompanyFields.NewAssessmentReportStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAppointmentPsychometristId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingNewAppointmentPsychometristId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAppointmentPsychometrist", false);
				relation.AddEntityFieldPair(UserFields.UserId, CompanyFields.NewAppointmentPsychometristId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Company.NewAppointmentPsychologistId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingNewAppointmentPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NewAppointmentPsychologist", false);
				relation.AddEntityFieldPair(UserFields.UserId, CompanyFields.NewAppointmentPsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
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
