﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using PsychologicalServices.Data;
using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.FactoryClasses
{
	/// <summary>Generates IEntityFields2 instances for different kind of Entities.</summary>
	public partial class EntityFieldsFactory
	{
		/// <summary>Private CTor, no instantiation possible.</summary>
		private EntityFieldsFactory()
		{
		}

		/// <summary>General factory entrance method which will return an EntityFields object with the format generated by the factory specified</summary>
		/// <param name="relatedEntityType">The type of entity the fields are for</param>
		/// <returns>The IEntityFields2 instance requested</returns>
		public static IEntityFields2 CreateEntityFieldsObject(PsychologicalServices.Data.EntityType relatedEntityType)
		{
			IEntityFields2 fieldsToReturn=null;
			IInheritanceInfoProvider inheritanceProvider = InheritanceInfoProviderSingleton.GetInstance();
			IFieldInfoProvider fieldProvider = FieldInfoProviderSingleton.GetInstance();
			switch(relatedEntityType)
			{
				case PsychologicalServices.Data.EntityType.AddressEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AddressEntity");
					break;
				case PsychologicalServices.Data.EntityType.AddressTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AddressTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AppointmentEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AppointmentEntity");
					break;
				case PsychologicalServices.Data.EntityType.AppointmentAttributeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AppointmentAttributeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AppointmentStatusEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AppointmentStatusEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentAttributeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentAttributeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentClaimEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentClaimEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentColorEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentColorEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentMedRehabEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentNoteEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentNoteEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentReportEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportIssueInDisputeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentReportIssueInDisputeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeAttributeTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentTypeAttributeTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AssessmentTypeReportTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AttributeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AttributeEntity");
					break;
				case PsychologicalServices.Data.EntityType.AttributeTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "AttributeTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.CalendarNoteEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "CalendarNoteEntity");
					break;
				case PsychologicalServices.Data.EntityType.CityEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "CityEntity");
					break;
				case PsychologicalServices.Data.EntityType.ClaimEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ClaimEntity");
					break;
				case PsychologicalServices.Data.EntityType.ClaimantEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ClaimantEntity");
					break;
				case PsychologicalServices.Data.EntityType.ColorEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ColorEntity");
					break;
				case PsychologicalServices.Data.EntityType.CompanyEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "CompanyEntity");
					break;
				case PsychologicalServices.Data.EntityType.CompanyAttributeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "CompanyAttributeEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceAppointmentEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceAppointmentEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceDocumentEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceDocumentEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceLineEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceLineEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceStatusEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusChangeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceStatusChangeEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusPathsEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceStatusPathsEntity");
					break;
				case PsychologicalServices.Data.EntityType.InvoiceTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "InvoiceTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.IssueInDisputeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "IssueInDisputeEntity");
					break;
				case PsychologicalServices.Data.EntityType.NoteEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "NoteEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReferralSourceEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceAppointmentStatusSettingEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReferralSourceAppointmentStatusSettingEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReferralSourceTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReferralTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReferralTypeIssueInDisputeEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReportStatusEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReportStatusEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReportTypeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReportTypeEntity");
					break;
				case PsychologicalServices.Data.EntityType.ReportTypeInvoiceAmountEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "ReportTypeInvoiceAmountEntity");
					break;
				case PsychologicalServices.Data.EntityType.RightEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "RightEntity");
					break;
				case PsychologicalServices.Data.EntityType.RoleEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "RoleEntity");
					break;
				case PsychologicalServices.Data.EntityType.RoleRightEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "RoleRightEntity");
					break;
				case PsychologicalServices.Data.EntityType.UserEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "UserEntity");
					break;
				case PsychologicalServices.Data.EntityType.UserNoteEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "UserNoteEntity");
					break;
				case PsychologicalServices.Data.EntityType.UserRoleEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "UserRoleEntity");
					break;
				case PsychologicalServices.Data.EntityType.UserTravelFeeEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "UserTravelFeeEntity");
					break;
				case PsychologicalServices.Data.EntityType.UserUnavailabilityEntity:
					fieldsToReturn = fieldProvider.GetEntityFields(inheritanceProvider, "UserUnavailabilityEntity");
					break;
			}
			return fieldsToReturn;
		}
		
		/// <summary>General method which will return an array of IEntityFieldCore objects, used by the InheritanceInfoProvider. Only the fields defined in the entity are returned, no inherited fields.</summary>
		/// <param name="entityName">the name of the entity to get the fields for. Example: "CustomerEntity"</param>
		/// <returns>array of IEntityFieldCore fields, defined in the entity with the name specified</returns>
		internal static IEntityFieldCore[] CreateFields(string entityName)
		{
			IFieldInfoProvider fieldProvider = FieldInfoProviderSingleton.GetInstance();
			return fieldProvider.GetEntityFieldsArray(entityName);
		}
		



		#region Included Code

		#endregion
	}
}
