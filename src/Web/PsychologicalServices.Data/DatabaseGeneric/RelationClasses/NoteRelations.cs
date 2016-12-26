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
	/// <summary>Implements the static Relations variant for the entity: Note. </summary>
	public partial class NoteRelations
	{
		/// <summary>CTor</summary>
		public NoteRelations()
		{
		}

		/// <summary>Gets all relations of the NoteEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CalendarNoteEntityUsingNoteId);

			toReturn.Add(this.UserEntityUsingUpdateUserId);
			toReturn.Add(this.UserEntityUsingCreateUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NoteEntity and CalendarNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// Note.NoteId - CalendarNote.NoteId
		/// </summary>
		public virtual IEntityRelation CalendarNoteEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CalendarNote" , true);
				relation.AddEntityFieldPair(NoteFields.NoteId, CalendarNoteFields.NoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalendarNoteEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between NoteEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Note.UpdateUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUpdateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UpdateUser", false);
				relation.AddEntityFieldPair(UserFields.UserId, NoteFields.UpdateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NoteEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Note.CreateUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingCreateUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CreateUser", false);
				relation.AddEntityFieldPair(UserFields.UserId, NoteFields.CreateUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", true);
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
