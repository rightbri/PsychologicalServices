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
using System.Collections;
using System.Collections.Generic;
using PsychologicalServices.Data;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: AppointmentAttribute. </summary>
	public partial class AppointmentAttributeRelations
	{
		/// <summary>CTor</summary>
		public AppointmentAttributeRelations()
		{
		}

		/// <summary>Gets all relations of the AppointmentAttributeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AppointmentEntityUsingAppointmentId);
			toReturn.Add(this.AttributeEntityUsingAttributeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AppointmentAttributeEntity and AppointmentEntity over the m:1 relation they have, using the relation between the fields:
		/// AppointmentAttribute.AppointmentId - Appointment.AppointmentId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Appointment", false);
				relation.AddEntityFieldPair(AppointmentFields.AppointmentId, AppointmentAttributeFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentAttributeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AppointmentAttributeEntity and AttributeEntity over the m:1 relation they have, using the relation between the fields:
		/// AppointmentAttribute.AttributeId - Attribute.AttributeId
		/// </summary>
		public virtual IEntityRelation AttributeEntityUsingAttributeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Attribute", false);
				relation.AddEntityFieldPair(AttributeFields.AttributeId, AppointmentAttributeFields.AttributeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentAttributeEntity", true);
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
