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
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations
	{
		/// <summary>CTor</summary>
		public UserRelations()
		{
		}

		/// <summary>Gets all relations of the UserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentEntityUsingCreateUserId);
			toReturn.Add(this.AppointmentEntityUsingPsychologistId);
			toReturn.Add(this.AppointmentEntityUsingPsychometristId);
			toReturn.Add(this.AppointmentEntityUsingUpdateUserId);
			toReturn.Add(this.ArbitrationEntityUsingPsychologistId);
			toReturn.Add(this.AssessmentEntityUsingCreateUserId);
			toReturn.Add(this.AssessmentEntityUsingDocListWriterId);
			toReturn.Add(this.AssessmentEntityUsingNotesWriterId);
			toReturn.Add(this.AssessmentEntityUsingUpdateUserId);
			toReturn.Add(this.CompanyEntityUsingNewAppointmentPsychologistId);
			toReturn.Add(this.CompanyEntityUsingNewAppointmentPsychometristId);
			toReturn.Add(this.ConsultingAgreementEntityUsingPsychologistId);
			toReturn.Add(this.InvoiceEntityUsingPayableToId);
			toReturn.Add(this.NoteEntityUsingCreateUserId);
			toReturn.Add(this.NoteEntityUsingUpdateUserId);
			toReturn.Add(this.RawTestDataEntityUsingPsychologistId);
			toReturn.Add(this.UserNoteEntityUsingUserId);
			toReturn.Add(this.UserRoleEntityUsingUserId);
			toReturn.Add(this.UserTravelFeeEntityUsingUserId);
			toReturn.Add(this.UserUnavailabilityEntityUsingUserId);
			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			toReturn.Add(this.DocumentEntityUsingSpinnerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Appointment.CreateUserId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingCreateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.CreateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Appointment.PsychologistId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Appointment.PsychometristId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingPsychometristId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PsychometristAppointments" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.PsychometristId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Appointment.UpdateUserId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingUpdateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.UpdateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and ArbitrationEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Arbitration.PsychologistId
		/// </summary>
		public virtual IEntityRelation ArbitrationEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PsychologistArbitrations" , true);
				relation.AddEntityFieldPair(UserFields.UserId, ArbitrationFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Assessment.CreateUserId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingCreateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.CreateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Assessment.DocListWriterId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingDocListWriterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.DocListWriterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Assessment.NotesWriterId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingNotesWriterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.NotesWriterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Assessment.UpdateUserId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingUpdateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, AssessmentFields.UpdateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and CompanyEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Company.NewAppointmentPsychologistId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingNewAppointmentPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, CompanyFields.NewAppointmentPsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and CompanyEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Company.NewAppointmentPsychometristId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingNewAppointmentPsychometristId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(UserFields.UserId, CompanyFields.NewAppointmentPsychometristId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and ConsultingAgreementEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - ConsultingAgreement.PsychologistId
		/// </summary>
		public virtual IEntityRelation ConsultingAgreementEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ConsultingAgreements" , true);
				relation.AddEntityFieldPair(UserFields.UserId, ConsultingAgreementFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and InvoiceEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Invoice.PayableToId
		/// </summary>
		public virtual IEntityRelation InvoiceEntityUsingPayableToId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Invoices" , true);
				relation.AddEntityFieldPair(UserFields.UserId, InvoiceFields.PayableToId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and NoteEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Note.CreateUserId
		/// </summary>
		public virtual IEntityRelation NoteEntityUsingCreateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoteCreator" , true);
				relation.AddEntityFieldPair(UserFields.UserId, NoteFields.CreateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and NoteEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - Note.UpdateUserId
		/// </summary>
		public virtual IEntityRelation NoteEntityUsingUpdateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoteUpdater" , true);
				relation.AddEntityFieldPair(UserFields.UserId, NoteFields.UpdateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and RawTestDataEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - RawTestData.PsychologistId
		/// </summary>
		public virtual IEntityRelation RawTestDataEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RawTestDatas" , true);
				relation.AddEntityFieldPair(UserFields.UserId, RawTestDataFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserNote.UserId
		/// </summary>
		public virtual IEntityRelation UserNoteEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserNotes" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserNoteFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserRoleEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserRole.UserId
		/// </summary>
		public virtual IEntityRelation UserRoleEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserRoles" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserRoleFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserRoleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserTravelFeeEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserTravelFee.UserId
		/// </summary>
		public virtual IEntityRelation UserTravelFeeEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserTravelFees" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserTravelFeeFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserTravelFeeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserUnavailabilityEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserUnavailability.UserId
		/// </summary>
		public virtual IEntityRelation UserUnavailabilityEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserUnavailabilities" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserUnavailabilityFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserUnavailabilityEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between UserEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// User.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, UserFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// User.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, UserFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserEntity and DocumentEntity over the m:1 relation they have, using the relation between the fields:
		/// User.SpinnerId - Document.DocumentId
		/// </summary>
		public virtual IEntityRelation DocumentEntityUsingSpinnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Spinner", false);
				relation.AddEntityFieldPair(DocumentFields.DocumentId, UserFields.SpinnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DocumentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
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
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation AppointmentEntityUsingCreateUserIdStatic = new UserRelations().AppointmentEntityUsingCreateUserId;
		internal static readonly IEntityRelation AppointmentEntityUsingPsychologistIdStatic = new UserRelations().AppointmentEntityUsingPsychologistId;
		internal static readonly IEntityRelation AppointmentEntityUsingPsychometristIdStatic = new UserRelations().AppointmentEntityUsingPsychometristId;
		internal static readonly IEntityRelation AppointmentEntityUsingUpdateUserIdStatic = new UserRelations().AppointmentEntityUsingUpdateUserId;
		internal static readonly IEntityRelation ArbitrationEntityUsingPsychologistIdStatic = new UserRelations().ArbitrationEntityUsingPsychologistId;
		internal static readonly IEntityRelation AssessmentEntityUsingCreateUserIdStatic = new UserRelations().AssessmentEntityUsingCreateUserId;
		internal static readonly IEntityRelation AssessmentEntityUsingDocListWriterIdStatic = new UserRelations().AssessmentEntityUsingDocListWriterId;
		internal static readonly IEntityRelation AssessmentEntityUsingNotesWriterIdStatic = new UserRelations().AssessmentEntityUsingNotesWriterId;
		internal static readonly IEntityRelation AssessmentEntityUsingUpdateUserIdStatic = new UserRelations().AssessmentEntityUsingUpdateUserId;
		internal static readonly IEntityRelation CompanyEntityUsingNewAppointmentPsychologistIdStatic = new UserRelations().CompanyEntityUsingNewAppointmentPsychologistId;
		internal static readonly IEntityRelation CompanyEntityUsingNewAppointmentPsychometristIdStatic = new UserRelations().CompanyEntityUsingNewAppointmentPsychometristId;
		internal static readonly IEntityRelation ConsultingAgreementEntityUsingPsychologistIdStatic = new UserRelations().ConsultingAgreementEntityUsingPsychologistId;
		internal static readonly IEntityRelation InvoiceEntityUsingPayableToIdStatic = new UserRelations().InvoiceEntityUsingPayableToId;
		internal static readonly IEntityRelation NoteEntityUsingCreateUserIdStatic = new UserRelations().NoteEntityUsingCreateUserId;
		internal static readonly IEntityRelation NoteEntityUsingUpdateUserIdStatic = new UserRelations().NoteEntityUsingUpdateUserId;
		internal static readonly IEntityRelation RawTestDataEntityUsingPsychologistIdStatic = new UserRelations().RawTestDataEntityUsingPsychologistId;
		internal static readonly IEntityRelation UserNoteEntityUsingUserIdStatic = new UserRelations().UserNoteEntityUsingUserId;
		internal static readonly IEntityRelation UserRoleEntityUsingUserIdStatic = new UserRelations().UserRoleEntityUsingUserId;
		internal static readonly IEntityRelation UserTravelFeeEntityUsingUserIdStatic = new UserRelations().UserTravelFeeEntityUsingUserId;
		internal static readonly IEntityRelation UserUnavailabilityEntityUsingUserIdStatic = new UserRelations().UserUnavailabilityEntityUsingUserId;
		internal static readonly IEntityRelation AddressEntityUsingAddressIdStatic = new UserRelations().AddressEntityUsingAddressId;
		internal static readonly IEntityRelation CompanyEntityUsingCompanyIdStatic = new UserRelations().CompanyEntityUsingCompanyId;
		internal static readonly IEntityRelation DocumentEntityUsingSpinnerIdStatic = new UserRelations().DocumentEntityUsingSpinnerId;

		/// <summary>CTor</summary>
		static StaticUserRelations()
		{
		}
	}
}
