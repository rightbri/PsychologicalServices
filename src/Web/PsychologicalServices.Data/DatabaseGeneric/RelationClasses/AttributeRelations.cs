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
	/// <summary>Implements the static Relations variant for the entity: Attribute. </summary>
	public partial class AttributeRelations
	{
		/// <summary>CTor</summary>
		public AttributeRelations()
		{
		}

		/// <summary>Gets all relations of the AttributeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentAttributeEntityUsingAttributeId);
			toReturn.Add(this.AssessmentAttributeEntityUsingAttributeId);
			toReturn.Add(this.CompanyAttributeEntityUsingAttributeId);

			toReturn.Add(this.AttributeTypeEntityUsingAttributeTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AttributeEntity and AppointmentAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Attribute.AttributeId - AppointmentAttribute.AttributeId
		/// </summary>
		public virtual IEntityRelation AppointmentAttributeEntityUsingAttributeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AppointmentAttributes" , true);
				relation.AddEntityFieldPair(AttributeFields.AttributeId, AppointmentAttributeFields.AttributeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentAttributeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AttributeEntity and AssessmentAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Attribute.AttributeId - AssessmentAttribute.AttributeId
		/// </summary>
		public virtual IEntityRelation AssessmentAttributeEntityUsingAttributeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentAttributes" , true);
				relation.AddEntityFieldPair(AttributeFields.AttributeId, AssessmentAttributeFields.AttributeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentAttributeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AttributeEntity and CompanyAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Attribute.AttributeId - CompanyAttribute.AttributeId
		/// </summary>
		public virtual IEntityRelation CompanyAttributeEntityUsingAttributeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CompanyAttributes" , true);
				relation.AddEntityFieldPair(AttributeFields.AttributeId, CompanyAttributeFields.AttributeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyAttributeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AttributeEntity and AttributeTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Attribute.AttributeTypeId - AttributeType.AttributeTypeId
		/// </summary>
		public virtual IEntityRelation AttributeTypeEntityUsingAttributeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AttributeType", false);
				relation.AddEntityFieldPair(AttributeTypeFields.AttributeTypeId, AttributeFields.AttributeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeEntity", true);
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
