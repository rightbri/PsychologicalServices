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
	/// <summary>Implements the static Relations variant for the entity: ReferralSourceAppointmentStatusSetting. </summary>
	public partial class ReferralSourceAppointmentStatusSettingRelations
	{
		/// <summary>CTor</summary>
		public ReferralSourceAppointmentStatusSettingRelations()
		{
		}

		/// <summary>Gets all relations of the ReferralSourceAppointmentStatusSettingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AppointmentStatusEntityUsingAppointmentStatusId);
			toReturn.Add(this.InvoiceTypeEntityUsingInvoiceTypeId);
			toReturn.Add(this.ReferralSourceEntityUsingReferralSourceId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ReferralSourceAppointmentStatusSettingEntity and AppointmentStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralSourceAppointmentStatusSetting.AppointmentStatusId - AppointmentStatus.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusEntityUsingAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AppointmentStatus", false);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, ReferralSourceAppointmentStatusSettingFields.AppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceAppointmentStatusSettingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ReferralSourceAppointmentStatusSettingEntity and InvoiceTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralSourceAppointmentStatusSetting.InvoiceTypeId - InvoiceType.InvoiceTypeId
		/// </summary>
		public virtual IEntityRelation InvoiceTypeEntityUsingInvoiceTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InvoiceType", false);
				relation.AddEntityFieldPair(InvoiceTypeFields.InvoiceTypeId, ReferralSourceAppointmentStatusSettingFields.InvoiceTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceAppointmentStatusSettingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ReferralSourceAppointmentStatusSettingEntity and ReferralSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralSourceAppointmentStatusSetting.ReferralSourceId - ReferralSource.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralSource", false);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, ReferralSourceAppointmentStatusSettingFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceAppointmentStatusSettingEntity", true);
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
