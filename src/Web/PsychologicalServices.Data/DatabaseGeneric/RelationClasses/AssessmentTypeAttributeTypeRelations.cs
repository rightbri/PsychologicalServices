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
	/// <summary>Implements the static Relations variant for the entity: AssessmentTypeAttributeType. </summary>
	public partial class AssessmentTypeAttributeTypeRelations
	{
		/// <summary>CTor</summary>
		public AssessmentTypeAttributeTypeRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentTypeAttributeTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AssessmentTypeEntityUsingAssessmentTypeId);
			toReturn.Add(this.AttributeTypeEntityUsingAttributeTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeAttributeTypeEntity and AssessmentTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentTypeAttributeType.AssessmentTypeId - AssessmentType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AssessmentType", false);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, AssessmentTypeAttributeTypeFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeAttributeTypeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeAttributeTypeEntity and AttributeTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentTypeAttributeType.AttributeTypeId - AttributeType.AttributeTypeId
		/// </summary>
		public virtual IEntityRelation AttributeTypeEntityUsingAttributeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AttributeType", false);
				relation.AddEntityFieldPair(AttributeTypeFields.AttributeTypeId, AssessmentTypeAttributeTypeFields.AttributeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttributeTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeAttributeTypeEntity", true);
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