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
	/// <summary>Implements the static Relations variant for the entity: AppointmentStatus. </summary>
	public partial class AppointmentStatusRelations
	{
		/// <summary>CTor</summary>
		public AppointmentStatusRelations()
		{
		}

		/// <summary>Gets all relations of the AppointmentStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentEntityUsingAppointmentStatusId);
			toReturn.Add(this.CompanyEntityUsingNewAppointmentStatusId);
			toReturn.Add(this.ReferralSourceAppointmentStatusSettingEntityUsingAppointmentStatusId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AppointmentStatusEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentStatus.AppointmentStatusId - Appointment.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Appointments" , true);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, AppointmentFields.AppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentStatusEntity and CompanyEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentStatus.AppointmentStatusId - Company.NewAppointmentStatusId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingNewAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, CompanyFields.NewAppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AppointmentStatusEntity and ReferralSourceAppointmentStatusSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// AppointmentStatus.AppointmentStatusId - ReferralSourceAppointmentStatusSetting.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation ReferralSourceAppointmentStatusSettingEntityUsingAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralSourceAppointmentStatusSettings" , true);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, ReferralSourceAppointmentStatusSettingFields.AppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", true);
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
