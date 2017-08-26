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
	/// <summary>Implements the static Relations variant for the entity: AppointmentSequence. </summary>
	public partial class AppointmentSequenceRelations
	{
		/// <summary>CTor</summary>
		public AppointmentSequenceRelations()
		{
		}

		/// <summary>Gets all relations of the AppointmentSequenceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PsychometristInvoiceAmountEntityUsingAppointmentSequenceId);
			toReturn.Add(this.ReferralSourceAppointmentStatusSettingEntityUsingAppointmentSequenceId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AppointmentSequenceEntity and PsychometristInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentSequence.AppointmentSequenceId - PsychometristInvoiceAmount.AppointmentSequenceId
		/// </summary>
		public virtual IEntityRelation PsychometristInvoiceAmountEntityUsingAppointmentSequenceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PsychometristInvoiceAmounts" , true);
				relation.AddEntityFieldPair(AppointmentSequenceFields.AppointmentSequenceId, PsychometristInvoiceAmountFields.AppointmentSequenceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentSequenceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentSequenceEntity and ReferralSourceAppointmentStatusSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentSequence.AppointmentSequenceId - ReferralSourceAppointmentStatusSetting.AppointmentSequenceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceAppointmentStatusSettingEntityUsingAppointmentSequenceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralSourceAppointmentStatusSettings" , true);
				relation.AddEntityFieldPair(AppointmentSequenceFields.AppointmentSequenceId, ReferralSourceAppointmentStatusSettingFields.AppointmentSequenceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentSequenceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceAppointmentStatusSettingEntity", false);
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
