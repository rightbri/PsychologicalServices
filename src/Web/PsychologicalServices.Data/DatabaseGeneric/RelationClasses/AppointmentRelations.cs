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
	/// <summary>Implements the static Relations variant for the entity: Appointment. </summary>
	public partial class AppointmentRelations
	{
		/// <summary>CTor</summary>
		public AppointmentRelations()
		{
		}

		/// <summary>Gets all relations of the AppointmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentTaskEntityUsingAppointmentId);

			toReturn.Add(this.AddressEntityUsingLocationId);
			toReturn.Add(this.AppointmentStatusEntityUsingAppointmentStatusId);
			toReturn.Add(this.AssessmentEntityUsingAssessmentId);
			toReturn.Add(this.UserEntityUsingPsychometristId);
			toReturn.Add(this.UserEntityUsingPsychologistId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and AppointmentTaskEntity over the 1:n relation they have, using the relation between the fields:
		/// Appointment.AppointmentId - AppointmentTask.AppointmentId
		/// </summary>
		public virtual IEntityRelation AppointmentTaskEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(AppointmentFields.AppointmentId, AppointmentTaskFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentTaskEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Appointment.LocationId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, AppointmentFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and AppointmentStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Appointment.AppointmentStatusId - AppointmentStatus.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusEntityUsingAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AppointmentStatus", false);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, AppointmentFields.AppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and AssessmentEntity over the m:1 relation they have, using the relation between the fields:
		/// Appointment.AssessmentId - Assessment.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Assessment", false);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AppointmentFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Appointment.PsychometristId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPsychometristId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Psychometrist", false);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.PsychometristId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AppointmentEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Appointment.PsychologistId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Psychologist", false);
				relation.AddEntityFieldPair(UserFields.UserId, AppointmentFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", true);
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
