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
	/// <summary>Implements the static Relations variant for the entity: ReferralSource. </summary>
	public partial class ReferralSourceRelations
	{
		/// <summary>CTor</summary>
		public ReferralSourceRelations()
		{
		}

		/// <summary>Gets all relations of the ReferralSourceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentStatusInvoiceRateEntityUsingReferralSourceId);
			toReturn.Add(this.AssessmentEntityUsingReferralSourceId);
			toReturn.Add(this.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId);
			toReturn.Add(this.ReferralSourceInvoiceConfigurationEntityUsingReferralSourceId);

			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.ReferralSourceTypeEntityUsingReferralSourceTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and AppointmentStatusInvoiceRateEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralSource.ReferralSourceId - AppointmentStatusInvoiceRate.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusInvoiceRateEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentStatusInvoiceRates" , true);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, AppointmentStatusInvoiceRateFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusInvoiceRateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralSource.ReferralSourceId - Assessment.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Assessments" , true);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, AssessmentFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and AssessmentTypeInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralSource.ReferralSourceId - AssessmentTypeInvoiceAmount.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeInvoiceAmountEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentTypeInvoiceAmounts" , true);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, AssessmentTypeInvoiceAmountFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and ReferralSourceInvoiceConfigurationEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralSource.ReferralSourceId - ReferralSourceInvoiceConfiguration.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceInvoiceConfigurationEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralSourceInvoiceConfiguration" , true);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, ReferralSourceInvoiceConfigurationFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceInvoiceConfigurationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralSource.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, ReferralSourceFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ReferralSourceEntity and ReferralSourceTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralSource.ReferralSourceTypeId - ReferralSourceType.ReferralSourceTypeId
		/// </summary>
		public virtual IEntityRelation ReferralSourceTypeEntityUsingReferralSourceTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralSourceType", false);
				relation.AddEntityFieldPair(ReferralSourceTypeFields.ReferralSourceTypeId, ReferralSourceFields.ReferralSourceTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", true);
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
